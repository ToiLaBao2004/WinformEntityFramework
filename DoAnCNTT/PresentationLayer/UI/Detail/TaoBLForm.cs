﻿using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.UI.Detail
{
    public partial class TaoBLForm : Form
    {
        DBSanPham dbsp;
        DataTable dtSanPham = null;
        DBBienLai dbbl;
        string hd;
        int r = 0;

        public TaoBLForm()
        {
            InitializeComponent();
            dbsp = new DBSanPham();
            dbbl = new DBBienLai();
        }

        public void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = dbsp.LaySanPhamChoFormBienLai();

                dgv.DataSource = dbbl.LayBienLai();
                int s = dgv.RowCount + 1;
                string bl = "NH";
                if (s < 10)
                    bl = bl + "0000";
                else if (s < 100)
                    bl = bl + "000";
                else if (s < 1000)
                    bl = bl + "00";
                else if (s < 10000)
                    bl = bl + "0";
                textBoxMaBienLai.Text = bl + s;
                textBoxMaBienLai.Enabled = false;

            }
            catch (SqlException ex)
            {
                this.Close();
                MessageBox.Show("Không thể truy cập!!!\n\nLỗi: " + ex.Message);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void TaoBLForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FindNameText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hd = FindNameText.Text;
                dgvSanPham.DataSource = dbsp.FindSanPham(hd, "", "");

                if (dgvSanPham.RowCount > 1)
                {
                    hd = dgvSanPham.Rows[0].Cells[0].Value.ToString();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error searching for product: " + ex.Message);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null && !string.IsNullOrEmpty(textBoxSoLuong.Text) && !string.IsNullOrEmpty(textBoxGiaNhap.Text))
            {
                r = dgvSanPham.CurrentCell.RowIndex;
                string MaSP = dgvSanPham.Rows[r].Cells[1].Value.ToString();
                string TenSP = dgvSanPham.Rows[r].Cells[2].Value.ToString();
                string GN = textBoxGiaNhap.Text;
                string SL = textBoxSoLuong.Text;
                SoLuong.Text = (Int32.Parse(SoLuong.Text) + Int32.Parse(SL)).ToString();
                textBoxThanhTien.Text = (Int32.Parse(textBoxThanhTien.Text) + Int32.Parse(SL) * Int32.Parse(GN)).ToString();
                insertGridView.Rows.Add(new object[] { MaSP, TenSP, GN, SL });
            }
            else
            {
                MessageBox.Show("Please select a product and fill in quantity and cost.");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                if (insertGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để lưu.");
                }
                DialogResult result = MessageBox.Show("Bạn có chắc muốn lưu hóa đơn này không?", "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool invoiceSaved = dbbl.ThemBienLai(ref err, textBoxMaBienLai.Text, textBoxMaNhaCungCap.Text, dateTimePickerNgayThanhToan.Value, 0);
                    if (invoiceSaved)
                    {
                        bool detailsSaved = true;
                        foreach (DataGridViewRow row in insertGridView.Rows)
                        {
                            if (row.Cells["Product_ID"].Value != null)
                            {
                                string maSP = row.Cells["Product_ID"].Value.ToString();
                                int soLuong = Convert.ToInt32(row.Cells["Quantity"].Value);
                                int giaNhap = Convert.ToInt32(row.Cells["UnitCost"].Value);

                                bool detailSaved = dbbl.ThemChiTietBienLai(ref err, textBoxMaBienLai.Text, maSP, soLuong, giaNhap);
                                if (!detailSaved)
                                {
                                    detailsSaved = false;
                                    break;
                                }
                            }
                        }

                        if (detailsSaved)
                        {
                            MessageBox.Show("Đã lưu hóa đơn thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lưu hóa đơn thất bại. Lỗi: " + err);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lưu hóa đơn thất bại. Lỗi: " + err);
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác đã bị hủy bởi người dùng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        private void DeleButton_Click(object sender, EventArgs e)
        {
            if (insertGridView.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = insertGridView.CurrentRow.Index;
                    if (rowIndex >= 0)
                    {
                        SoLuong.Text = (Int32.Parse(SoLuong.Text) - Int32.Parse(insertGridView.Rows[rowIndex].Cells[3].Value.ToString())).ToString();
                        textBoxThanhTien.Text = (Int32.Parse(textBoxThanhTien.Text) - Int32.Parse(insertGridView.Rows[rowIndex].Cells[2].Value.ToString()) * Int32.Parse(insertGridView.Rows[rowIndex].Cells[3].Value.ToString())).ToString();
                        insertGridView.Rows.RemoveAt(rowIndex);
                        MessageBox.Show("Đã xóa hàng thành công.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
            }
        }
    }
}

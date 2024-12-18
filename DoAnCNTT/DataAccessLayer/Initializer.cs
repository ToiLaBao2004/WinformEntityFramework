﻿using System;
using System.Data.Entity;
using DataAccessLayer.Entities;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer
{
    public class Initializer : CreateDatabaseIfNotExists<QLCuaHang>
    {
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển đổi byte array thành chuỗi ký tự
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected override void Seed(QLCuaHang context)
        {

            var brands = new[]
            {
                new Brand { Brand_ID = "YNX", BrandName = "Yonex" },
                new Brand { Brand_ID = "LN", BrandName = "Lining" },
                new Brand { Brand_ID = "ADD", BrandName = "Adidas" },
                new Brand { Brand_ID = "KMT", BrandName = "Kamito" },
                new Brand { Brand_ID = "KWS", BrandName = "Kawasaki" },
                new Brand { Brand_ID = "NIK", BrandName = "Nike" },
                new Brand { Brand_ID = "PKN", BrandName = "Prokennex" },
                new Brand { Brand_ID = "PN", BrandName = "Pan" }
            };
            context.Brands.AddOrUpdate(b => b.Brand_ID, brands);


            var categories = new[]
            {
                new Category { Category_ID = "ACL", CategoryName = "Áo cầu lông" },
                new Category { Category_ID = "BĐBĐ", CategoryName = "Bộ đồ bóng đá" },
                new Category { Category_ID = "GBĐ", CategoryName = "Giày bóng đá" },
                new Category { Category_ID = "GCL", CategoryName = "Giày cầu lông" },
                new Category { Category_ID = "PK", CategoryName = "Phụ kiện" },
                new Category { Category_ID = "QCL", CategoryName = "Quần cầu lông" },
                new Category { Category_ID = "VCL", CategoryName = "Vợt cầu lông" }
            };
            context.Categories.AddOrUpdate(c => c.Category_ID, categories);


            var discounts = new[]
            {
                new Discount { DiscountCode = "BLFRIDAY", PercentageDiscount = 30, StartDay = DateTime.Parse("2024-11-25"), EndDay = DateTime.Parse("2024-12-02") },
                new Discount { DiscountCode = "12THANG12", PercentageDiscount = 30, StartDay = DateTime.Parse("2024-12-11"), EndDay = DateTime.Parse("2024-12-12") }
            };
            context.Discounts.AddOrUpdate(c => c.DiscountCode, discounts);

            
            var pictureNames = new[]
            {
                "AocaulongYonexDen.jpg",
                "AocaulongYonexTrang.jpg",
                "KamitoTienMinhLegend.jpg",
                "KamitoVTTGowo.jpg",
                "Kawasaki065Do.jpg",
                "Kawasaki065Trang.jpg",
                "LiningAxforce70.jpg",
                "LiningAxforce80.jpg",
                "LiningAxforce90.jpg",
                "LiningChenLongAYZU011-1.jpg",
                "OngcaulongLining.jpg",
                "OngcaulongYonex.jpg",
                "PanPatriotEVOPodTFDo.jpg",
                "PanPatriotEVOPodTFTrang.jpg",
                "PanPatriotEVOPodTFVang.jpg",
                "ProKennexPowerPro705.jpg",
                "ProKennexThunder7004.jpg",
                "QuancancaulongLining.jpg",
                "QuancancaulongYonex.jpg",
                "YonexAstrox88D2018.jpg",
                "YonexAstrox88DPro2022.jpg",
                "YonexAstrox88S2018.jpg",
                "YonexAstrox88SPro2022.jpg",
                "YonexAstrox99Navy2020.jpg",
                "YonexAstrox99Pro2022.jpg",
                "YonexEclipsionZ3MenNavy.jpg",
                "YonexSHB65Z3WhiteTiger.jpg",
                "YonexSHB65Z3WomanNavy.jpg",
                "AdidasXCrazyfastMessi.jpg",
                "AobongdaNikekhonglogoDen.jpg",
                "AobongdaNikekhonglogoTrang.jpg",
                "NikeGalaxyCR7.jpg",
                "YonexEclipsionZ3WomanWhite.jpg",
                "QuanCauLongYonexTrang.jpg",
                "QuanCauLongYonexDen.jpg"
            };
            foreach (var picture in pictureNames)
            {
                var pictureProduct = new PictureProduct { Picture_Name = picture };
                context.PictureProducts.AddOrUpdate(pictureProduct);
            }


            var employees = new[]
            {
                new Employee{
                    EmployeeID = "BH01",
                    NameEmployee = "Ngô Thị Mai Anh",
                    Birthday = DateTime.Parse("1985-12-30"),
                    Gender = "Nu",
                    AddressEmployee = "5 Đường Lê Lợi, Quận 3, TP.HCM",
                    PhoneNumber = "0918575678",
                    RoleEmployee = "Bán hàng",
                    Active = "1",
                    PassWordAccount = HashPassword("bh01")
                },
                new Employee
                {
                    EmployeeID = "BH02",
                    NameEmployee = "Lương Văn Tuấn",
                    Birthday = DateTime.Parse("1982-09-26"),
                    Gender = "Nam",
                    AddressEmployee = "125 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM",
                    PhoneNumber = "0978545412",
                    RoleEmployee = "Bán hàng",
                    Active = "1",
                    PassWordAccount = HashPassword("bh02")
                },
                new Employee
                {
                    EmployeeID = "BH03",
                    NameEmployee = "Võ Thị Mỹ Lợi",
                    Birthday = new DateTime(2004, 04, 08),
                    Gender = "Nữ",
                    AddressEmployee = "Bình Định",
                    PhoneNumber = "0372260578",
                    RoleEmployee = "Bán hàng",
                    Active = "1",
                    PassWordAccount = HashPassword("bh03")
                },
                new Employee
                {
                    EmployeeID = "QL01",
                    NameEmployee = "Nguyễn Hoài Bảo",
                    Birthday = DateTime.Parse("2004-02-17"),
                    Gender = "Nam",
                    AddressEmployee = "Lâm Đồng",
                    PhoneNumber = "0363609039",
                    RoleEmployee = "Quản lí",
                    Active = "1",
                    PassWordAccount = HashPassword("baodeptrai")
                }
            };
            context.Employees.AddOrUpdate(p => p.EmployeeID, employees);


            var customers = new[]
            {
                new Customer { PhoneNumber = "0901236767", NameCustomer = "Trần Đức Anh", Birthday = DateTime.Parse("2009-03-15"), Gender = "Nam", Point = 256 },
                new Customer { PhoneNumber = "0912345678", NameCustomer = "Nguyễn Thị Hương", Birthday = DateTime.Parse("1997-07-20"), Gender = "Nu", Point = 743 },
                new Customer { PhoneNumber = "0923455789", NameCustomer = "Lê Văn Nam", Birthday = DateTime.Parse("1995-09-25"), Gender = "Nam", Point = 512 },
                new Customer { PhoneNumber = "0934586890", NameCustomer = "Phạm Thị Loan", Birthday = DateTime.Parse("2000-07-20"), Gender = "Nu", Point = 899 },
                new Customer { PhoneNumber = "0944567901", NameCustomer = "Hoàng Minh Tuấn", Birthday = DateTime.Parse("2005-04-05"), Gender = "Nam", Point = 347 },
                new Customer { PhoneNumber = "0959839012", NameCustomer = "Vũ Thị Lan Anh", Birthday = DateTime.Parse("1988-06-12"), Gender = "Nu", Point = 631 },
                new Customer { PhoneNumber = "0967801423", NameCustomer = "Đặng Xuân Hải", Birthday = DateTime.Parse("1993-04-05"), Gender = "Nam", Point = 178 },
                new Customer { PhoneNumber = "0978986234", NameCustomer = "Bùi Hồng Loan", Birthday = DateTime.Parse("2002-10-22"), Gender = "Nu", Point = 425 },
                new Customer { PhoneNumber = "0989013345", NameCustomer = "Đỗ Quang Huy", Birthday = DateTime.Parse("1980-12-28"), Gender = "Nam", Point = 568 },
                new Customer { PhoneNumber = "0990124756", NameCustomer = "Ngô Thị Hà", Birthday = DateTime.Parse("1978-02-03"), Gender = "Nu", Point = 937 }
            };
            context.Customers.AddOrUpdate(p => p.PhoneNumber, customers);

            
            var products = new[]
            {
                new Product { Product_ID = "88D2018", ProductName = "Yonex Astrox 88D 2018", UnitPrice = 6500000, Quantity = 0, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 20 },
                new Product { Product_ID = "88DP2022", ProductName = "Yonex Astrox 88D Pro 2022", UnitPrice = 4900000, Quantity = 6, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 21 },
                new Product { Product_ID = "88DS2022", ProductName = "Yonex Astrox 88S Pro 2022", UnitPrice = 4800000, Quantity = 0, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 23 },
                new Product { Product_ID = "88S2018", ProductName = "Yonex Astrox 88S 2018", UnitPrice = 6400000, Quantity = 0, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 22 },
                new Product { Product_ID = "99NAVY2020", ProductName = "Yonex Astrox 99 Navy 2020", UnitPrice = 5000000, Quantity = 0, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 24 },
                new Product { Product_ID = "99PRO2022", ProductName = "Yonex Astrox 99 Pro 2022", UnitPrice = 5500000, Quantity = 0, Brand_ID = "YNX", Category_ID = "VCL", Picture_ID = 25 },
                new Product { Product_ID = "ACLYĐL", ProductName = "Áo cầu lông Yonex Đen Size L", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 1 },
                new Product { Product_ID = "ACLYĐM", ProductName = "Áo cầu lông Yonex Đen Size M", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 1 },
                new Product { Product_ID = "ACLYĐS", ProductName = "Áo cầu lông Yonex Đen Size S", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 1 },
                new Product { Product_ID = "ACLYĐXL", ProductName = "Áo cầu lông Yonex Đen Size XL", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 1 },
                new Product { Product_ID = "ACLYĐXXL", ProductName = "Áo cầu lông Yonex Đen Size XXL", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 1 },
                new Product { Product_ID = "ACLYTL", ProductName = "Áo cầu lông Yonex Trắng Size L", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 2 },
                new Product { Product_ID = "ACLYTM", ProductName = "Áo cầu lông Yonex Trắng Size M", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 2 },
                new Product { Product_ID = "ACLYTS", ProductName = "Áo cầu lông Yonex Trắng Size S", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 2 },
                new Product { Product_ID = "ACLYTXL", ProductName = "Áo cầu lông Yonex Trắng Size XL", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 2 },
                new Product { Product_ID = "ACLYTXXL", ProductName = "Áo cầu lông Yonex Trắng Size XXL", UnitPrice = 200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "ACL", Picture_ID = 2 },
                new Product { Product_ID = "ANKLĐL", ProductName = "Áo bóng đá Nike không logo Đen Size L", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 30 },
                new Product { Product_ID = "ANKLĐM", ProductName = "Áo bóng đá Nike không logo Đen Size M", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 30 },
                new Product { Product_ID = "ANKLĐS", ProductName = "Áo bóng đá Nike không logo Đen Size S", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 30 },
                new Product { Product_ID = "ANKLĐXL", ProductName = "Áo bóng đá Nike không logo Đen Size XL", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 30 },
                new Product { Product_ID = "ANKLĐXXL", ProductName = "Áo bóng đá Nike không logo Đen Size XXL", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 30 },
                new Product { Product_ID = "ANKLTL", ProductName = "Áo bóng đá Nike không logo Trắng Size L", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 31 },
                new Product { Product_ID = "ANKLTM", ProductName = "Áo bóng đá Nike không logo Trắng Size M", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 31 },
                new Product { Product_ID = "ANKLTS", ProductName = "Áo bóng đá Nike không logo Trắng Size S", UnitPrice = 150000, Quantity = 8, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 31 },
                new Product { Product_ID = "ANKLTXL", ProductName = "Áo bóng đá Nike không logo Trắng Size XL", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 31 },
                new Product { Product_ID = "ANKLTXXL", ProductName = "Áo bóng đá Nike không logo Trắng Size XXL", UnitPrice = 150000, Quantity = 0, Brand_ID = "NIK", Category_ID = "BĐBĐ", Picture_ID = 31 },
                new Product { Product_ID = "AX70", ProductName = "Lining Axforce 70", UnitPrice = 4500000, Quantity = 9, Brand_ID = "LN", Category_ID = "VCL", Picture_ID = 7 },
                new Product { Product_ID = "AX80", ProductName = "Lining Axforce 80", UnitPrice = 5000000, Quantity = 0, Brand_ID = "LN", Category_ID = "VCL", Picture_ID = 8 },
                new Product { Product_ID = "AX90", ProductName = "Lining Axforce 90", UnitPrice = 5400000, Quantity = 18, Brand_ID = "LN", Category_ID = "VCL", Picture_ID = 9 },
                new Product { Product_ID = "AXM39", ProductName = "Adidas X Crazyfast Messi Size 39", UnitPrice = 2000000, Quantity = 9, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "AXM40", ProductName = "Adidas X Crazyfast Messi Size 40", UnitPrice = 2000000, Quantity = 9, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "AXM41", ProductName = "Adidas X Crazyfast Messi Size 41", UnitPrice = 2000000, Quantity = 0, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "AXM42", ProductName = "Adidas X Crazyfast Messi Size 42", UnitPrice = 2000000, Quantity = 0, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "AXM43", ProductName = "Adidas X Crazyfast Messi Size 43", UnitPrice = 2000000, Quantity = 0, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "AXM44", ProductName = "Adidas X Crazyfast Messi Size 44", UnitPrice = 2000000, Quantity = 0, Brand_ID = "ADD", Category_ID = "GBĐ", Picture_ID = 29 },
                new Product { Product_ID = "KMTTML", ProductName = "Kamito Tiến Minh Legend", UnitPrice = 2300000, Quantity = 9, Brand_ID = "KMT", Category_ID = "VCL", Picture_ID = 3 },
                new Product { Product_ID = "KMTVTT", ProductName = "Kamito VTT Gowo", UnitPrice = 1700000, Quantity = 0, Brand_ID = "KMT", Category_ID = "VCL", Picture_ID = 4 },
                new Product { Product_ID = "KWS065Đ39", ProductName = "Kawasaki 065 Đỏ Size 39", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065Đ40", ProductName = "Kawasaki 065 Đỏ Size 40", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065Đ41", ProductName = "Kawasaki 065 Đỏ Size 41", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065Đ42", ProductName = "Kawasaki 065 Đỏ Size 42", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065Đ43", ProductName = "Kawasaki 065 Đỏ Size 43", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065Đ44", ProductName = "Kawasaki 065 Đỏ Size 44", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 5 },
                new Product { Product_ID = "KWS065T39", ProductName = "Kawasaki 065 Trắng Size 39", UnitPrice = 800000, Quantity = 12, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6 },
                new Product { Product_ID = "KWS065T40", ProductName = "Kawasaki 065 Trắng Size 40", UnitPrice = 800000, Quantity = 13, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6 },
                new Product { Product_ID = "KWS065T41", ProductName = "Kawasaki 065 Trắng Size 41", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6 },
                new Product { Product_ID = "KWS065T42", ProductName = "Kawasaki 065 Trắng Size 42", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6},
                new Product { Product_ID = "KWS065T43", ProductName = "Kawasaki 065 Trắng Size 43", UnitPrice = 800000, Quantity = 9, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6 },
                new Product { Product_ID = "KWS065T44", ProductName = "Kawasaki 065 Trắng Size 44", UnitPrice = 800000, Quantity = 0, Brand_ID = "KWS", Category_ID = "GCL", Picture_ID = 6 },
                new Product { Product_ID = "LCA39", ProductName = "Lining ChenLong AYZU011-1 Size 39", UnitPrice = 2650000, Quantity = 0, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "LCA40", ProductName = "Lining ChenLong AYZU011-1 Size 40", UnitPrice = 2650000, Quantity = 8, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "LCA41", ProductName = "Lining ChenLong AYZU011-1 Size 41", UnitPrice = 2650000, Quantity = 0, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "LCA42", ProductName = "Lining ChenLong AYZU011-1 Size 42", UnitPrice = 2650000, Quantity = 0, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "LCA43", ProductName = "Lining ChenLong AYZU011-1 Size 43", UnitPrice = 2650000, Quantity = 0, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "LCA44", ProductName = "Lining ChenLong AYZU011-1 Size 44", UnitPrice = 2650000, Quantity = 0, Brand_ID = "LN", Category_ID = "GCL", Picture_ID = 10 },
                new Product { Product_ID = "NGCR39", ProductName = "Nike Galaxy CR7 Size 39", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "NGCR40", ProductName = "Nike Galaxy CR7 Size 40", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "NGCR41", ProductName = "Nike Galaxy CR7 Size 41", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "NGCR42", ProductName = "Nike Galaxy CR7 Size 42", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "NGCR43", ProductName = "Nike Galaxy CR7 Size 43", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "NGCR44", ProductName = "Nike Galaxy CR7 Size 44", UnitPrice = 2000000, Quantity = 0, Brand_ID = "NIK", Category_ID = "GBĐ", Picture_ID = 32 },
                new Product { Product_ID = "PKPP705", ProductName = "Pro Kennex Power Pro 705", UnitPrice = 800000, Quantity = 0, Brand_ID = "PKN", Category_ID = "VCL", Picture_ID = 16 },
                new Product { Product_ID = "PKT7004", ProductName = "Pro Kennex Thunder 7004", UnitPrice = 900000, Quantity = 0, Brand_ID = "PKN", Category_ID = "VCL", Picture_ID = 17 },
                new Product { Product_ID = "PPTEP39ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 39", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ",  Picture_ID = 13 },
                new Product { Product_ID = "PPTEP39TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 39", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP39TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 39", UnitPrice = 620000, Quantity = 8, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP39VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 39", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "PPTEP40ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 40", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 13 },
                new Product { Product_ID = "PPTEP40TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 40", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP40TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 40", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP40VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 40", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "PPTEP41ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 41", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 13 },
                new Product { Product_ID = "PPTEP41TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 41", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP41TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 41", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP41VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 41", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "PPTEP42ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 42", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 13 },
                new Product { Product_ID = "PPTEP42TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 42", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP42TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 42", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP42VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 42", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "PPTEP43ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 43", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 13 },
                new Product { Product_ID = "PPTEP43TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 43", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP43TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 43", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP43VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 43", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "PPTEP44ĐTF", ProductName = "Pan Patriot EVO Pod TF Đỏ Size 44", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 13 },
                new Product { Product_ID = "PPTEP44TIC", ProductName = "Pan Patriot EVO Pod IC Trắng Size 44", UnitPrice = 610000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP44TTF", ProductName = "Pan Patriot EVO Pod TF Trắng Size 44", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 14 },
                new Product { Product_ID = "PPTEP44VTF", ProductName = "Pan Patriot EVO Pod TF Vàng Size 44", UnitPrice = 620000, Quantity = 0, Brand_ID = "PN", Category_ID = "GBĐ", Picture_ID = 15 },
                new Product { Product_ID = "QCCLL", ProductName = "Quấn cán cầu lông Lining", UnitPrice = 20000, Quantity = 0, Brand_ID = "LN", Category_ID = "PK", Picture_ID = 18 },
                new Product { Product_ID = "QCCLY", ProductName = "Quấn cán cầu lông Yonex", UnitPrice = 50000, Quantity = 0, Brand_ID = "YNX", Category_ID = "PK", Picture_ID = 19 },
                new Product { Product_ID = "QCL", ProductName = "Ống cầu lông Lining", UnitPrice = 200000, Quantity = 0, Brand_ID = "LN", Category_ID = "PK", Picture_ID = 11 },
                new Product { Product_ID = "QCY", ProductName = "Ống cầu lông Yonex", UnitPrice = 1200000, Quantity = 0, Brand_ID = "YNX", Category_ID = "PK", Picture_ID = 12 },
                new Product { Product_ID = "Y65Z3WN39", ProductName = "Yonex SHB 65 Z3 Woman Navy Size 39", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 28 },
                new Product { Product_ID = "Y65Z3WN40", ProductName = "Yonex SHB 65 Z3 Woman Navy Size 40", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 28 },
                new Product { Product_ID = "Y65Z3WN41", ProductName = "Yonex SHB 65 Z3 Woman Navy Size 41", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 28 },
                new Product { Product_ID = "Y65Z3WN42", ProductName = "Yonex SHB 65 Z3 Woman Navy Size 42", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 28 },
                new Product { Product_ID = "Y65Z3WT39", ProductName = "Yonex SHB 65 Z3 White Tiger Size 39", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "Y65Z3WT40", ProductName = "Yonex SHB 65 Z3 White Tiger Size 40", UnitPrice = 2700000, Quantity = 9, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "Y65Z3WT41", ProductName = "Yonex SHB 65 Z3 White Tiger Size 41", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "Y65Z3WT42", ProductName = "Yonex SHB 65 Z3 White Tiger Size 42", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "Y65Z3WT43", ProductName = "Yonex SHB 65 Z3 White Tiger Size 43", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "Y65Z3WT44", ProductName = "Yonex SHB 65 Z3 White Tiger Size 44", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 27 },
                new Product { Product_ID = "YEZ3NAVY39", ProductName = "Yonex Eclipsion Z3 Men Navy Size 39", UnitPrice = 2700000, Quantity = 22, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3NAVY40", ProductName = "Yonex Eclipsion Z3 Men Navy Size 40", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3NAVY41", ProductName = "Yonex Eclipsion Z3 Men Navy Size 41", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3NAVY42", ProductName = "Yonex Eclipsion Z3 Men Navy Size 42", UnitPrice = 2700000, Quantity = 9, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3NAVY43", ProductName = "Yonex Eclipsion Z3 Men Navy Size 43", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3NAVY44", ProductName = "Yonex Eclipsion Z3 Men Navy Size 44", UnitPrice = 2700000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 26 },
                new Product { Product_ID = "YEZ3WHITE39", ProductName = "Yonex Eclipsion Z3 Woman White Size 39", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 33 },
                new Product { Product_ID = "YEZ3WHITE40", ProductName = "Yonex Eclipsion Z3 Woman White Size 40", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 33 },
                new Product { Product_ID = "YEZ3WHITE41", ProductName = "Yonex Eclipsion Z3 Woman White Size 41", UnitPrice = 2600000, Quantity = 9, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 33 },
                new Product { Product_ID = "YEZ3WHITE42", ProductName = "Yonex Eclipsion Z3 Woman White Size 42", UnitPrice = 2600000, Quantity = 0, Brand_ID = "YNX", Category_ID = "GCL", Picture_ID = 33 },
                new Product { Product_ID = "QCLYN955DS", ProductName = "Quần Cầu Lông Yonex 955 Trắng Size S", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 34 },
                new Product { Product_ID = "QCLYN955DM", ProductName = "Quần Cầu Lông Yonex 955 Trắng Size M", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 34 },
                new Product { Product_ID = "QCLYN955DL", ProductName = "Quần Cầu Lông Yonex 955 Trắng Size L", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 34 },
                new Product { Product_ID = "QCLYN955DXL", ProductName = "Quần Cầu Lông Yonex 955 Trắng Size XL", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 34 },
                new Product { Product_ID = "QCLYN955TS", ProductName = "Quần Cầu Lông Yonex 955 Đen Size S", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 35 },
                new Product { Product_ID = "QCLYN955TM", ProductName = "Quần Cầu Lông Yonex 955 Đen Size M", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 35 },
                new Product { Product_ID = "QCLYN955TL", ProductName = "Quần Cầu Lông Yonex 955 Đen Size L", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 35 },
                new Product { Product_ID = "QCLYN955TXL", ProductName = "Quần Cầu Lông Yonex 955 Đen Size XL", UnitPrice = 130000, Quantity = 0, Brand_ID = "YNX", Category_ID = "QCL", Picture_ID = 35 }
            };
            context.Products.AddOrUpdate(p => p.Product_ID, products);


            var suppliers = new[]
            {
                new Supplier { Supplier_ID = "ATS", CompanyName = "Anh Thắng Sport", PhoneNumber = "0981122234", AddressSupplier = "41 Đường C1, P13, Q. Tân Bình, TP Hồ Chí Minh", Email = "anhthangsport.com" },
                new Supplier { Supplier_ID = "VNB", CompanyName = "Vietnam Badminton", PhoneNumber = "0977508430", AddressSupplier = "20 Cao Bá Nhạ, Phường Nguyễn Cư Trinh, Quận 1, TPHCM", Email = "info@shopvnb.com" },
                new Supplier { Supplier_ID = "YNS", CompanyName = "Yonex Sunrise Vietnam", PhoneNumber = "0363609038", AddressSupplier = "157 Điện Biên Phủ, Phường Đa Kao, Quận 1, Thành Phố Hồ Chí Minh, Việt Nam", Email = "sunrisevn@risesun.com.sg" }
            };
            context.Suppliers.AddOrUpdate(p => p.Supplier_ID, suppliers);


            var imports = new[]
            {
                new Import { Import_ID = "NH00001", Supplier_ID = "ATS", ImportDay = DateTime.Parse("2024-01-15"), Total = 234230000 },
                new Import { Import_ID = "NH00002", Supplier_ID = "VNB", ImportDay = new DateTime(2024, 1, 15), Total = 61100000 },
                new Import { Import_ID = "NH00003", Supplier_ID = "YNS", ImportDay = new DateTime(2024, 1, 15), Total = 89050000 }
            };
            context.Imports.AddOrUpdate(p => p.Import_ID, imports);


            var importDetails = new[]
            {
                new ImportDetail { Import_ID = "NH00001", Product_ID = "KWS065T39", Quantity = 13, Unitcost = 700000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "LCA40", Quantity = 9, Unitcost = 2450000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "KWS065T43", Quantity = 9, Unitcost = 700000 },
                new ImportDetail { Import_ID = "NH00003", Product_ID = "YEZ3NAVY39", Quantity = 22, Unitcost = 2550000 },
                new ImportDetail { Import_ID = "NH00003", Product_ID = "YEZ3WHITE41", Quantity = 4, Unitcost = 2500000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "ANKLTS", Quantity = 8, Unitcost = 135000 },
                new ImportDetail { Import_ID = "NH00003", Product_ID = "YEZ3NAVY42", Quantity = 9, Unitcost = 2550000 },
                new ImportDetail { Import_ID = "NH00002", Product_ID = "YEZ3WHITE41", Quantity = 5, Unitcost = 2500000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "KWS065T40", Quantity = 13, Unitcost = 700000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "AX70", Quantity = 9, Unitcost = 4200000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "AX90", Quantity = 18, Unitcost = 5100000 },
                new ImportDetail { Import_ID = "NH00002", Product_ID = "88DP2022", Quantity = 6, Unitcost = 4500000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "KMTTML", Quantity = 9, Unitcost = 2100000 },
                new ImportDetail { Import_ID = "NH00002", Product_ID = "Y65Z3WT40", Quantity = 9, Unitcost = 2400000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "PPTEP39TTF", Quantity = 8, Unitcost = 600000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "AXM39", Quantity = 9, Unitcost = 1850000 },
                new ImportDetail { Import_ID = "NH00001", Product_ID = "AXM40", Quantity = 9, Unitcost = 1850000 }
            };
            context.ImportDetails.AddOrUpdate(p => new { p.Import_ID, p.Product_ID }, importDetails);


            var orders = new[]
            {
                new Order { Order_ID = "HD00001", PhoneNumber = "0923455789", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-08"), Total = 3450000, DiscountCode = null },
                new Order { Order_ID = "HD00002", PhoneNumber = "0934586890", EmployeeID = "BH01", OrderDate = DateTime.Parse("2024-11-09"), Total = 800000, DiscountCode = null },
                new Order { Order_ID = "HD00003", PhoneNumber = "0901236767", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-10"), Total = 8100000, DiscountCode = null },
                new Order { Order_ID = "HD00004", PhoneNumber = "0912345678", EmployeeID = "BH01", OrderDate = DateTime.Parse("2024-11-10"), Total = 300000, DiscountCode = null },
                new Order { Order_ID = "HD00005", PhoneNumber = "0923455789", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-10"), Total = 5300000, DiscountCode = null },
                new Order { Order_ID = "HD00006", PhoneNumber = "0934586890", EmployeeID = "BH01", OrderDate = DateTime.Parse("2024-11-11"), Total = 800000, DiscountCode = null },
                new Order { Order_ID = "HD00007", PhoneNumber = "0944567901", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-12"), Total = 15300000, DiscountCode = null },
                new Order { Order_ID = "HD00008", PhoneNumber = "0959839012", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-13"), Total = 9800000, DiscountCode = null },
                new Order { Order_ID = "HD00009", PhoneNumber = "0967801423", EmployeeID = "BH02", OrderDate = DateTime.Parse("2024-11-14"), Total = 2300000, DiscountCode = null },
                new Order { Order_ID = "HD00010", PhoneNumber = "0978986234", EmployeeID = "BH02", OrderDate = DateTime.Parse("2024-11-15"), Total = 2700000, DiscountCode = null },
                new Order { Order_ID = "HD00011", PhoneNumber = "0989013345", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-16"), Total = 1240000, DiscountCode = null },
                new Order { Order_ID = "HD00012", PhoneNumber = "0990124756", EmployeeID = "QL01", OrderDate = DateTime.Parse("2024-11-17"), Total = 4000000, DiscountCode = null },
            };
            context.Orders.AddOrUpdate(p => p.Order_ID, orders);


            var orderDetails = new[]
            {
                new OrderDetail { Order_ID = "HD00001", Product_ID = "KWS065T39", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00001", Product_ID = "LCA40", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00002", Product_ID = "KWS065T43", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00003", Product_ID = "YEZ3NAVY39", Quantity = 2 },
                new OrderDetail { Order_ID = "HD00003", Product_ID = "YEZ3WHITE41", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00004", Product_ID = "ANKLTS", Quantity = 2 },
                new OrderDetail { Order_ID = "HD00005", Product_ID = "YEZ3NAVY42", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00005", Product_ID = "YEZ3WHITE41", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00006", Product_ID = "KWS065T40", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00007", Product_ID = "AX70", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00007", Product_ID = "AX90", Quantity = 2 },
                new OrderDetail { Order_ID = "HD00008", Product_ID = "88DP2022", Quantity = 2 },
                new OrderDetail { Order_ID = "HD00009", Product_ID = "KMTTML", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00010", Product_ID = "Y65Z3WT40", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00011", Product_ID = "PPTEP39TTF", Quantity = 2 },
                new OrderDetail { Order_ID = "HD00012", Product_ID = "AXM39", Quantity = 1 },
                new OrderDetail { Order_ID = "HD00012", Product_ID = "AXM40", Quantity = 1 },
            };
            context.OrderDetails.AddOrUpdate(p => new { p.Order_ID, p.Product_ID }, orderDetails);


            context.SaveChanges();
        }
    }
}

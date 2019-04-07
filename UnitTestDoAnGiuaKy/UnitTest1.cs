using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoAnWeb;
using DoAnWeb.Controllers;
using DoAnWeb.Areas;
using DoAnWeb.Models;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace UnitTestDoAnGiuaKy
{
    [TestClass]
    public class UnitTest1
    {
        //string connectionString = "metadata=res://*/DoAnWeb.csdl|res://*/DoAnWeb.ssdl|res://*/DoAnWeb.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-297T8GT;initial catalog=DoAnNganh;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        //string connectionString = "data source=DESKTOP-297T8GT;initial catalog=DoAnNganh;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        //public virtual void OpenConectionString(string con)
        //{
        //    using (var connction = new SqlConnection(con))
        //    {
        //        connction.Open();
        //    }
        //}
        #region Test Login
        [TestInitialize]
        public void TestInitialize()
        {
            string ConnectionString = @"data source=DESKTOP-297T8GT;initial catalog=DoAnNganh;" +
                "integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }
        [TestMethod]
        //[TestInitialize]
        public void TestLogin()
        {
            string username = "admin";
            string password = "admin2019";
            DoAnWeb.NguoiDung nd = new NguoiDung();
            nd.TenNguoiDung = username;
            nd.PassWord = password; ;
            DoAnWeb.Areas.Admin.Controllers.AdminLoginController ctrl = new DoAnWeb.Areas.Admin.Controllers.AdminLoginController();
            var result = ctrl.AdminLogin(nd) as JsonResult;
            var mes = result.Data.ToString();
            Assert.AreEqual("success", mes);
        }
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        
        [TestMethod]
        public void TestLoginErrorPassword()
        {
            string username = "admin";
            string password = "abc@123456";
            DoAnWeb.NguoiDung nd = new NguoiDung();
            nd.TenNguoiDung = username;
            nd.PassWord = password; ;
            DoAnWeb.Areas.Admin.Controllers.AdminLoginController ctrl = new DoAnWeb.Areas.Admin.Controllers.AdminLoginController();
            var result = ctrl.AdminLogin(nd) as JsonResult;
            var mes = result.Data.ToString();
            Assert.AreNotEqual("success", mes);
        }
        [TestMethod]
        public void TestLoginPassWordNull()
        {
            string username = "admin";
            string password = "";
            DoAnWeb.NguoiDung nd = new NguoiDung();
            nd.TenNguoiDung = username;
            nd.PassWord = password; ;
            DoAnWeb.Areas.Admin.Controllers.AdminLoginController ctrl = new DoAnWeb.Areas.Admin.Controllers.AdminLoginController();
            var result = ctrl.AdminLogin(nd) as JsonResult;
            var mes = result.Data.ToString();
            Assert.AreNotEqual("success", mes);
        }
        [TestMethod]
        public void TestLoginUserPassError()
        {
            string username = "admin";
            string password = "admin";
            DoAnWeb.NguoiDung nd = new NguoiDung();
            nd.TenNguoiDung = username;
            nd.PassWord = password; ;
            DoAnWeb.Areas.Admin.Controllers.AdminLoginController ctrl = new DoAnWeb.Areas.Admin.Controllers.AdminLoginController();
            var result = ctrl.AdminLogin(nd) as JsonResult;
            var mes = result.Data.ToString();
            Assert.AreNotEqual("success", mes);
        }
        [TestMethod]
        public void TestLoginUserNull()
        {
            string username = "";
            string password = "admin2019";
            DoAnWeb.NguoiDung nd = new NguoiDung();
            nd.TenNguoiDung = username;
            nd.PassWord = password; ;
            DoAnWeb.Areas.Admin.Controllers.AdminLoginController ctrl = new DoAnWeb.Areas.Admin.Controllers.AdminLoginController();
            var result = ctrl.AdminLogin(nd) as JsonResult;
            var mes = result.Data.ToString();
            Assert.AreNotEqual("success", mes);
        }
        #endregion
        #region phần về sản phẩm
        [TestMethod]
        public void TestAddProduct()
        {
            DoAnWeb.Xe xe = new Xe();
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            xe.ChiTiet = "Unit Test";
            xe.CreatedDate = DateTime.Now;
            xe.GiaNiemYetXe = 10000;
            xe.GiaVonXe = 5000;
            xe.Hinh1 = "banner.jpg";
            xe.Hinh2 = "banner1.jpg";
            xe.Hinh3 = "banner2.jpg";
            xe.IdKhoXe = Guid.Parse("ACBA9D50-0AC8-47B3-BE54-B2EC5DD5686C");
            xe.IdNhaCungCap = Guid.Parse("F3409D77-8847-43BA-B408-2C51470B2FAC");
            xe.MaLoaiXe = Guid.Parse("89E51C6D-C3F2-4448-B819-100BF449F70F");
            xe.SoMay = "SM123456";
            xe.SoKhung = "SK123456";
            var result = ctrl.ThemXe(xe,"");
            var mes = result.Data.ToString();
            Assert.AreEqual("Bạn đã thêm xe thành công.", mes);
        }
        [TestMethod]
        public void TestGuiEmail()
        {
            string SoKhung = "sokhung123";
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            ctrl.GuiEmail(SoKhung);
            //Assert.IsTrue("",ctrl.GuiEmail(SoKhung));
        }
        [TestMethod]
        public void TestAddProductNew()
        {
            DoAnWeb.Xe xe = new Xe();
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            xe.ChiTiet = "Unit Test";
            xe.CreatedDate = DateTime.Now;
            xe.GiaNiemYetXe = 10000;
            xe.GiaVonXe = 5000;
            xe.Hinh1 = "banner.jpg";
            xe.Hinh2 = "banner1.jpg";
            xe.Hinh3 = "banner2.jpg";
            xe.IdKhoXe = Guid.Parse("ACBA9D50-0AC8-47B3-BE54-B2EC5DD5686C");
            xe.IdNhaCungCap = Guid.Parse("F3409D77-8847-43BA-B408-2C51470B2FAC");
            xe.MaLoaiXe = Guid.Parse("89E51C6D-C3F2-4448-B819-100BF449F70F");
            xe.SoMay = "SM123456";
            xe.SoKhung = "SK123456";
            string listhinh = "";
            var result = ctrl.ThemXe(xe,listhinh);
            var mes = result.Data.ToString();
            Assert.AreEqual("Bạn đã thêm xe thành công.", mes);
        }
        [TestMethod]
        public void TestListTypeCar()
        {
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            var result = ctrl.InitalLoaiXe();
            var mes = result.Data.ToString();
            Assert.AreNotEqual(null,mes);
        }
        [TestMethod]
        public void TestInitalKhoXe()
        {
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            var result = ctrl.InitalKhoXe();
            var mes = result.Data.ToString();
            Assert.AreNotEqual(null, mes);
        }
        [TestMethod]
        public void TestThemLoaiXe()
        {
            DoAnWeb.LoaiXe loaixe = new LoaiXe();
            loaixe.CreatedDate = DateTime.Now;
            loaixe.MauXe = "";
            loaixe.SoLuong = 100;
            loaixe.TenLoaiXe = "Audi";
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            var result = ctrl.ThemLoaiXe(loaixe);
            var mes = result.Data.ToString();
            Assert.AreEqual("Success", mes);
        }
        [TestMethod]
        public void TestDanhSachXe()
        {
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            var result = ctrl.DanhSachXe();
            var mes = result.Data.ToString();
            Assert.AreNotEqual(null, mes);
        }
        [TestMethod]
        public void UploadFiles()
        {
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            object obj = new object();
            var result = ctrl.UploadFiles(obj);
            Assert.AreNotEqual("{0} bytes uploaded", result);
        }
        [TestMethod]
        public void TestUpdateSoLuongLoaiXe()
        {
            Guid IdLoaiXe = Guid.Parse("89E51C6D-C3F2-4448-B819-100BF449F70F");
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            ctrl.UpdateSoLuongLoaiXe(IdLoaiXe);
            //Assert.AreNotEqual("{0} bytes uploaded", result);
        }
        #endregion
    }
}

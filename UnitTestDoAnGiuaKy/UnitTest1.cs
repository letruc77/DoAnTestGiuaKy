﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoAnWeb;
using DoAnWeb.Controllers;
using DoAnWeb.Areas;
using DoAnWeb.Models;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;

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
        [TestMethod]
        public void TestCapNhatLoaiXe()
        {
            DoAnWeb.LoaiXe lx = new LoaiXe();
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            string result = ctrl.CapNhatLoaiXe(lx);
            Assert.AreNotEqual("Success", result);
        }
        [TestMethod]
        public void TestCapNhatKho()
        {
            DoAnWeb.KhoXe lx = new KhoXe();
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            string result = ctrl.CapNhatKho(lx);
            Assert.AreNotEqual("Success", result);
        }
        //thêm nhà cung cấp có trùng id 
        [TestMethod]
        public void DSNhaCungCap()
        {
            DoAnWeb.Areas.Admin.Controllers.SupplierController ctrl = new DoAnWeb.Areas.Admin.Controllers.SupplierController();
            var result = ctrl.LoadNCC();
            var mes = result.Data.ToString();
            Assert.AreNotEqual(null, mes);
        }
        [TestMethod]
        public void ThemNCC()
        {
            DoAnWeb.Areas.Admin.Controllers.SupplierController ctrl = new DoAnWeb.Areas.Admin.Controllers.SupplierController();
            DoAnWeb.NhaCungCap ncc = new NhaCungCap();
            var result = ctrl.ThemNhaCungCap(ncc);
            Assert.AreNotEqual("Thêm thành công", result);
        }
        [TestMethod]
        public void ThemNCCId()
        {
            DoAnWeb.Areas.Admin.Controllers.SupplierController ctrl = new DoAnWeb.Areas.Admin.Controllers.SupplierController();
            DoAnWeb.NhaCungCap ncc = new NhaCungCap();
            ncc.IdNhaCungCap = Guid.Parse("F3409D77-8847-43BA-B408-2C51470B2FAC");
            var result = ctrl.ThemNhaCungCap(ncc);
            Assert.AreEqual("Đã xảy ra lỗi!", result);
        }
        [TestMethod]
        public void CapNhatNCC()
        {
            DoAnWeb.Areas.Admin.Controllers.SupplierController ctrl = new DoAnWeb.Areas.Admin.Controllers.SupplierController();
            DoAnWeb.NhaCungCap ncc = new NhaCungCap();
            //ncc.IdNhaCungCap = Guid.Parse("F3409D77-8847-43BA-B408-2C51470B2FAC");
            var result = ctrl.ThemNhaCungCap(ncc);
            Assert.AreEqual("Đã xảy ra lỗi!", result);
        }
        [TestMethod]
        public void TestAddProductNewNotPicture()
        {
            DoAnWeb.Xe xe = new Xe();
            DoAnWeb.Areas.Admin.Controllers.ProductsController ctrl = new DoAnWeb.Areas.Admin.Controllers.ProductsController();
            xe.ChiTiet = "Unit Test";
            xe.CreatedDate = DateTime.Now;
            xe.GiaNiemYetXe = 10000;
            xe.GiaVonXe = 5000;
            xe.IdKhoXe = Guid.Parse("ACBA9D50-0AC8-47B3-BE54-B2EC5DD5686C");
            xe.IdNhaCungCap = Guid.Parse("F3409D77-8847-43BA-B408-2C51470B2FAC");
            xe.MaLoaiXe = Guid.Parse("89E51C6D-C3F2-4448-B819-100BF449F70F");
            xe.SoMay = "SM123456";
            xe.SoKhung = "SK123456";
            string listhinh = "";
            var result = ctrl.ThemXe(xe, listhinh);
            var mes = result.Data.ToString();
            Assert.AreEqual("Bạn đã thêm xe thành công.", mes);
        }
        #endregion
        #region test về giao diện
        [TestMethod]
        public void BanChayNhat()
        {
            DoAnWeb.Controllers.HomeController ctrl = new HomeController();
            List<Xe> listXe = new List<Xe>();
            DoAnWebEntities daw = new DoAnWebEntities();
            daw.Configuration.ProxyCreationEnabled = false;
            var result = ctrl.LoadListXeBest();
            int count = 0;
            foreach(var item in result.Data.ToString())
            {
                count++;
            }
            Assert.AreEqual(9, count);
        }
        [TestMethod]
        public void MoiNhat()
        {
            DoAnWeb.Controllers.HomeController ctrl = new HomeController();
            List<Xe> listXe = new List<Xe>();
            DoAnWebEntities daw = new DoAnWebEntities();
            daw.Configuration.ProxyCreationEnabled = false;
            var result = ctrl.LoadListXeNew();
            int count = 0;
            foreach (var item in result.Data.ToString())
            {
                count++;
            }
            Assert.AreNotEqual(9, count);
        }
        [TestMethod]
        public void ChiTiet(string data)
        {
            DoAnWeb.Controllers.HomeController ctrl = new HomeController();
            ActionResult result = ctrl.Single(data);
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void AddCartItem(Guid SanPhamID, int SoLuong)
        {
            DoAnWeb.Controllers.CartController ctrl = new CartController();
            ActionResult result = ctrl.AddItem(SanPhamID, SoLuong);
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void InitalCart()
        {
            DoAnWeb.Controllers.CartController ctrl = new CartController();
            var result = ctrl.Index();
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void DeleteItemInCart()
        {
            string id = "";
            DoAnWeb.Controllers.CartController ctrl = new CartController();
            var result = ctrl.Delete(id);
            Assert.AreEqual(true, result.Data);
        }
        [TestMethod]
        public void DeleteAllInCart()
        {
            DoAnWeb.Controllers.CartController ctrl = new CartController();
            var result = ctrl.DeleteAll();
            Assert.AreEqual(true, result.Data);
        }
        #endregion
        #region Login vao hệ thống
        [TestMethod]
        public void LoginUser()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "letruc9394@gmail.com";
            nd.PassWord = "admin2019";
            var result = ctrl.Login(nd);
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void LoginUserTrue()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "letruc9394@gmail.com";
            nd.PassWord = "admin2019";
            var result = ctrl.Login(nd);
            Assert.AreEqual(nd, result.Data);
        }
        [TestMethod]
        public void LoginUserFalse()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "thlong@gmail.com";
            nd.PassWord = "1";
            var result = ctrl.Login(nd);
            Assert.AreNotEqual(nd, result.Data);
        }
        [TestMethod]
        public void LoginUserFalsePassword()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "thlong@gmail.com";
            nd.PassWord = "";
            var result = ctrl.Login(nd);
            Assert.AreNotEqual(nd, result.Data);
        }
        [TestMethod]
        public void LoginUserFalseEmail()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "thlong@gmail";
            nd.PassWord = "admin2019";
            var result = ctrl.Login(nd);
            Assert.AreNotEqual(nd, result.Data);
        }
        [TestMethod]
        public void LoginUserFalseNoPassWord()
        {
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            NguoiDung nd = new NguoiDung();
            nd.Email = "thlong@gmail.com";
            nd.PassWord = "";
            var result = ctrl.Login(nd);
            Assert.AreNotEqual(nd, result.Data);
        }
        [TestMethod]
        public void RegisterUserFalseNoPassWord()
        {
            NguoiDung nd = new NguoiDung();
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            nd.Email = "truc.lecong@gmail.com";
            nd.PassWord = "";
            var result = ctrl.Register(nd);
            Assert.AreNotEqual("Đăng ký thành công!", result);
        }
        [TestMethod]
        public void RegisterUser()
        {
            NguoiDung nd = new NguoiDung();
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            nd.Email = "letruc9394@gmail.com";
            nd.PassWord = "";
            var result = ctrl.Register(nd);
            Assert.AreEqual("Trùng user!", result);
        }
        [TestMethod]
        public void RegisterUserFalse()
        {
            NguoiDung nd = new NguoiDung();
            DoAnWeb.Controllers.LoginController ctrl = new LoginController();
            nd.Email = "";
            nd.PassWord = "";
            var result = ctrl.Register(nd);
            Assert.AreEqual("Trùng user!", result);
        }
        #endregion
    }

}


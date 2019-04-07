using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoAnWeb;
using DoAnWeb.Controllers;
using DoAnWeb.Areas;
using DoAnWeb.Models;
using System.Web.Mvc;

namespace UnitTestDoAnGiuaKy
{
    [TestClass]
    public class UnitTest1
    {
        #region Test Login
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
        public void TestLogin()
        {
            // ba noi m truc
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
            var result = ctrl.ThemXe(xe,"");
            var mes = result.Data.ToString();
            Assert.AreEqual("success", mes);
        }
        #endregion
    }
}

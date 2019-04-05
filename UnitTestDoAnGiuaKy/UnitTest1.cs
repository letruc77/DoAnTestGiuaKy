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
        public void TestLogin2()
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
    }
}

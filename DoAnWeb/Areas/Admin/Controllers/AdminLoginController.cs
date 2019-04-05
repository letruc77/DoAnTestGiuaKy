using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminLoginController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        // GET: Admin/AdminLogin
        [AllowAnonymous]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult AdminLogin(NguoiDung nguoiDung)
        {
            string message = "";
            var passWord = "";
            try
            {
                if (nguoiDung.TenNguoiDung == "admin")
                {
                    passWord = GetMD5(nguoiDung.PassWord);
                    nguoiDung = daw.NguoiDungs.Where(n => n.TenNguoiDung == nguoiDung.TenNguoiDung && n.PassWord == passWord).FirstOrDefault();
                    if (nguoiDung != null)
                        message = "success";
                    else
                        message = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                else
                    message = "Chỉ có admin mới có quyền đăng nhập";
            }
            catch (Exception ex)
            {
                nguoiDung = new NguoiDung();
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //[AllowAnonymous]
        //[HttpPost]
        //public JsonResult AdminLogin(NguoiDung nguoiDung)
        //{
        //    string message = "";
        //    var passWord = "";
        //    try
        //    {
        //        if (nguoiDung.TenNguoiDung == "admin")
        //        {
        //            passWord = GetMD5(nguoiDung.PassWord);
        //            nguoiDung = daw.NguoiDungs.Where(n => n.TenNguoiDung == nguoiDung.TenNguoiDung && n.PassWord == passWord).FirstOrDefault();
        //            if (nguoiDung != null)
        //                message = "success";
        //            else
        //                message = "Tên đăng nhập hoặc mật khẩu không đúng";
        //        }
        //        else
        //            message = "Chỉ có admin mới có quyền đăng nhập";
        //    }
        //    catch (Exception ex)
        //    {
        //        nguoiDung = new NguoiDung();
        //    }
        //    return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

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
    }
}
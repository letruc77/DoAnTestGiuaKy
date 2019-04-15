using DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class LoginController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        private string AccountSession = "AccountSession";
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(NguoiDung nguoidung)
        {
            try
            {
                var passWord = GetMD5(nguoidung.PassWord);
                nguoidung = daw.NguoiDungs.Where(n => n.Email == nguoidung.Email && n.PassWord == passWord).FirstOrDefault();
                if (nguoidung != null)
                {
                    var account = Session[AccountSession];
                    // tạo mới đối tượng Account
                    var item = new NguoiDung();
                    item.IdNguoiDung = nguoidung.IdNguoiDung;
                    item.TenNguoiDung = nguoidung.TenNguoiDung;
                    var list = new List<NguoiDung>();
                    list.Add(item);
                    // gán vào session
                    Session[AccountSession] = list;
                }
            }
            catch (Exception ex)
            {
                nguoidung = new NguoiDung();
            }
            return new JsonResult { Data = nguoidung, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult LogOut()
        {
            // xóa user đăng nhập
            Session[AccountSession] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(NguoiDung nguoidung)
        {
            string message = "";
            try
            {
                NguoiDung nd = daw.NguoiDungs.Where(x => x.Email == nguoidung.Email && x.IsDeleted == false).FirstOrDefault();
                if (nd != null)
                {
                    nguoidung.IdNguoiDung = Guid.NewGuid();
                    nguoidung.PassWord = GetMD5(nguoidung.PassWord);
                    nguoidung.IsDeleted = false;
                    nguoidung.TinhTrang = true;
                    nguoidung.CreatedDate = DateTime.Now;
                    nguoidung.UpdatedDate = DateTime.Now;
                    daw.NguoiDungs.Add(nguoidung);
                    daw.SaveChanges();
                    message = "Đăng ký thành công!";
                }
                else
                    message = "Trùng user!";
            }
            catch (Exception ex)
            {
                message = "Đã có lỗi xãy ra !";
            }

            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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


    }
}
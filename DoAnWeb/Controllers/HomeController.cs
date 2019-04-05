using DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //phần về load xe cho trang chủ
        //load list danh sach xe moi nhat
        [HttpGet]
        public JsonResult LoadListXeNew()
        {
            List<Xe> listXe = new List<Xe>();
            try
            {
                using (DoAnWebEntities daw = new DoAnWebEntities())
                {
                    daw.Configuration.ProxyCreationEnabled = false;
                    listXe = daw.Xes.Where(x => x.IsDeleted == false && x.TinhTrang == "NEW").OrderByDescending(x => x.NgayNhap).ToList();
                    if(listXe.Count > 9)
                        listXe = listXe.Take(9).ToList();
                    else
                    {
                        var listXeThem = daw.Xes.Where(x=>x.TinhTrang != "NEW" && x.IsDeleted == false).OrderByDescending(x => x.NgayNhap).ToList();
                        listXeThem = listXeThem.Take(9 - listXe.Count).ToList();
                        if(listXeThem.Count > 0)
                        {
                            foreach(var item in listXeThem)
                            {
                                listXe.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
            }
            return new JsonResult { Data = listXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //load list xe cos nhieu luot xem nhat
        [HttpGet]
        public JsonResult LoadListXeBest()
        {
            List<Xe> listXe = new List<Xe>();
            try
            {
                using (DoAnWebEntities daw = new DoAnWebEntities())
                {
                    daw.Configuration.ProxyCreationEnabled = false;
                    listXe = daw.Xes.Where(x => x.IsDeleted == false && x.TinhTrang == "NEW").OrderByDescending(x => x.SoLuotXem).ToList();
                    //listXe = listXe.Take(9).ToList();
                    if (listXe.Count > 9)
                        listXe = listXe.Take(9).ToList();
                    else
                    {
                        var listXeThem = daw.Xes.Where(x => x.TinhTrang != "NEW" && x.IsDeleted == false).OrderByDescending(x => x.SoLuotXem).ToList();
                        listXeThem = listXeThem.Take(9 - listXe.Count).ToList();
                        if (listXeThem.Count > 0)
                        {
                            foreach (var item in listXeThem)
                            {
                                listXe.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return new JsonResult { Data = listXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //phần chi tiết của trang chủ
        public ActionResult Single()
        {
            return View();
        }
        //chi tiet xe
        [HttpGet]
        public ActionResult Single(string data)
        {
            string url = Request.Url.AbsoluteUri;
            string[] ArrayUrl = url.Split('/');
            int count = ArrayUrl.Length;
            if(data == null)
            {
                data = ArrayUrl[count - 1];
            }
            Xe xe = new Xe();
            try
            {
                using (DoAnWebEntities daw = new DoAnWebEntities())
                {
                    Guid idXe = new Guid(data);
                    xe = daw.Xes.Where(x => x.IsDeleted == false && x.IdXe == idXe).FirstOrDefault();
                    if (xe != null)
                        UpdateSoLuongXe(idXe);
                }
            }
            catch (Exception ex)
            {
            }
            //return new JsonResult { Data = xe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            ViewBag.Xe = xe;
            return View();
        }
        private void UpdateSoLuongXe(Guid IdXe)
        {
            try
            {
                using (DoAnWebEntities daw = new DoAnWebEntities())
                {
                    Xe xe = daw.Xes.Where(x => x.IdXe == IdXe && x.IsDeleted == false).FirstOrDefault();
                    if(xe != null)
                    {
                        xe.SoLuotXem = xe.SoLuotXem + 1;
                        daw.Xes.Attach(xe);
                        daw.Entry(xe).State = EntityState.Modified;
                        daw.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [ChildActionOnly]
        public PartialViewResult CartView()
        {
            string CartSession = "CartSession";
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
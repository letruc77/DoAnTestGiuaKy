using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        // GET: Admin/Revenue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Revenue_Thu()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InitalThu(string TuNgay, string DenNgay)
        {
            try
            {
                DateTime tuNgay = DateTime.Parse(TuNgay);
                DateTime denNgay = DateTime.Parse(DenNgay);
                daw.Configuration.ProxyCreationEnabled = false;
                var ListThu = daw.HoaDonThus.Where(x => x.NgayThu >= tuNgay && x.NgayThu <= denNgay && x.IsDeleted == false).ToList();
                return new JsonResult { Data = ListThu, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {

            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Revenue_Chi()
        {
            return View();
        }
    }
}
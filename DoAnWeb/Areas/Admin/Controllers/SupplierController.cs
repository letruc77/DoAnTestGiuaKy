using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        public ActionResult NhaCungCapIndex()
        {
            return View();
        }
        // GET: Admin/Supplier
        [HttpGet]
        public JsonResult LoadNCC()
        {
            List<NhaCungCap> listNCC = new List<NhaCungCap>();
            try
            {
                daw.Configuration.ProxyCreationEnabled = false;
                listNCC = daw.NhaCungCaps.Where(x => x.IsDeleted == false).ToList();
                //var listNCC = (from ncc in daw.NhaCungCaps
                //           where ncc.IsDeleted == false
                //           select ncc);
                return new JsonResult { Data = listNCC, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public JsonResult InitalNCC_New()
        {
            daw.Configuration.ProxyCreationEnabled = false;
            List<NhaCungCap> listNCC = new List<NhaCungCap>();
            try
            {
                listNCC = daw.NhaCungCaps.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
            }
            return new JsonResult { Data = listNCC, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult ThemNhaCungCap()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ThemNhaCungCap(NhaCungCap NCC)
        {
            string message = "";
            try
            {
                NhaCungCap ncc = daw.NhaCungCaps.Where(x => x.TenNCC == NCC.TenNCC.Trim() && x.IsDeleted == false).FirstOrDefault();
                if (ncc != null)
                {
                    //ncc.TenNCC = NCC.TenNCC;
                    //ncc.DiaChi = NCC.DiaChi;
                    //ncc.TinhTrang = NCC.TinhTrang;
                    //ncc.IsDeleted = NCC.IsDeleted;
                    //daw.NhaCungCaps.Attach(ncc);
                    //daw.SaveChanges();
                    message = "Đã có nhà cung cấp này rồi!";
                }
                else
                {
                    if(NCC.IdNhaCungCap.ToString() != "00000000-0000-0000-0000-000000000000" || NCC.IdNhaCungCap.ToString() != "" || NCC.IdNhaCungCap.ToString() != null)
                        NCC.IdNhaCungCap = Guid.NewGuid();
                    NCC.TinhTrang = true;
                    NCC.IsDeleted = false;
                    daw.NhaCungCaps.Add(NCC);
                    daw.SaveChanges();
                    message = "Thêm thành công";
                }
            }
            catch (Exception ex)
            {
                message = "Đã xảy ra lỗi!";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
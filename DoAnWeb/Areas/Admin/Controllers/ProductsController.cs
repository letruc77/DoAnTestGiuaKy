using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;
using Newtonsoft.Json;
namespace DoAnWeb.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        // GET: Admin/Products
        #region phần CRUD của xe
        public ActionResult Index()
        {
            daw.Configuration.ProxyCreationEnabled = false;
            return View();
        }
        public ActionResult ThemXe()
        {
            daw.Configuration.ProxyCreationEnabled = false;
            return View();
        }
        [HttpGet]
        public JsonResult DanhSachXe()
        {
            try
            {
                daw.Configuration.ProxyCreationEnabled = false;
                //var query = (from a in db1
                //             join b in db2 on a.EnteredBy equals b.UserId
                //             where a.LHManifestNum == LHManifestNum
                //             select new { LHManifestId = a.LHManifestId, LHManifestNum = a.LHManifestNum, LHManifestDate = a.LHManifestDate, StnCode = a.StnCode, Operatr = b.UserName }).FirstOrDefault();
                var listXe = (from x in daw.Xes
                                    join l in daw.LoaiXes on x.MaLoaiXe equals l.IdLoaiXe
                                    join n in daw.NhaCungCaps on x.IdNhaCungCap equals n.IdNhaCungCap
                                    join k in daw.KhoXes on x.IdKhoXe equals k.IdKhoXe
                                    where x.IsDeleted == false
                                    select new { x.GiaNiemYetXe,x.GiaVonXe,x.Hinh1,x.SoKhung
                                    , x.SoMay,x.TinhTrang,x.IdXe,x.ChiTiet,x.TenXe
                                    , l.TenLoaiXe, n.TenNCC, k.TenKho }
                                ).ToList();
                return new JsonResult { Data = listXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //ham de upload hinh anh xe
        public bool UploadImage(string pathImages)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if(Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Path.GetExtension(file.FileName);
                int size = file.ContentLength;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Images"),fileName));
                    flag = true;
                }
                catch (Exception ex)
                {
                    Message = "Lỗi upload hình ảnh xe.";
                }
            }
            return flag;
        }

        [HttpPost]
        public virtual string UploadFiles(object obj)
        {
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];

            var saveToFileLoc = Path.Combine(Server.MapPath("~/Images/product/") + fileName);

            // save the file.
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();

            return string.Format("{0} bytes uploaded", bytes.Length);
        }

        [HttpPost]
        public JsonResult ThemXe(Xe xe, string listhinh)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using(DoAnWebEntities daw = new DoAnWebEntities())
                {
                    try
                    {
                        Xe dt = daw.Xes.Where(x=>(x.SoKhung == xe.SoKhung || x.SoMay == xe.SoMay) && x.IsDeleted == false).FirstOrDefault();
                        if(dt!=null)
                        {
                            message = "Số khung hoặc số máy này đã có trong dữ liệu";
                        }
                        else
                        {
                            xe.CreatedDate = DateTime.Now;
                            xe.CreatedBy = Guid.Parse("2DAD25D4-A75F-405C-B405-468D4F8E1D3A");
                            xe.IdXe = Guid.NewGuid();
                            xe.SoLuotXem = 0;
                            xe.TinhTrang = "NEW";
                            xe.IsDeleted = false;
                            daw.Xes.Add(xe);
                            daw.SaveChanges();
                            message = "Bạn đã thêm xe thành công.";
                            if (message == "Bạn đã thêm xe thành công.")
                            {
                                UpdateSoLuongLoaiXe(xe.MaLoaiXe.Value);
                                //gửi email đến người dùng là có xe mới nhập về
                                GuiEmail(xe.SoKhung);
                            } 
                        }
                    }
                    catch (Exception ex)
                    {
                        message = "Đã xảy ra lỗi khi thêm thêm xe mới.";
                    }
                }
            }
            else
            {
                message = "Đã xảy ra lỗi khi thêm thêm xe mới.";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //Update lại số lượng của loại xe mà xe đc thêm
        public void UpdateSoLuongLoaiXe(Guid idLoaiXe)
        {
            try
            {
                LoaiXe loaiXe = daw.LoaiXes.Where(x => x.IdLoaiXe == idLoaiXe && x.IsDeleted == false).FirstOrDefault();
                if(loaiXe != null)
                {
                    loaiXe.SoLuong = loaiXe.SoLuong + 1;
                    daw.LoaiXes.Attach(loaiXe);
                    daw.Entry(loaiXe).State = EntityState.Modified;
                    daw.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }
        //gửi email cho khách hàng
        public void GuiEmail(string soKhung)
        {
            try
            {
                List<NguoiDung> lstNguoiDung = new List<NguoiDung>();
                Xe xe = new Xe();
                MailHelper Mail = new MailHelper();
                if(soKhung != "" && soKhung != null)
                {
                    xe = daw.Xes.Where(x => x.SoKhung == soKhung && x.IsDeleted == false).FirstOrDefault();
                }
                lstNguoiDung = daw.NguoiDungs.Where(x => x.TenNguoiDung != "admin" && x.IsDeleted == false).ToList();
                if(lstNguoiDung.Count > 0 && soKhung != "")
                {
                    foreach(var item in lstNguoiDung)
                    {
                        Mail.SendMail(item.Email, "Thông báo có xe mới từ Car Việt"
                            , "Cửa hàng Car Việt của chúng tôi vừa mới nhập xe " + xe.TenXe + " vào ngày hôm nay. Quý khách có nhu cầu vui lòng liên hệ với chúng tôi hoặc đến tại show room của chúng tôi. Xin chân thành cảm ơn!");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion
        #region lấy danh sách kho và loại xe để thêm xe mới

        [HttpGet]
        public JsonResult InitalLoaiXe()
        {
            try
            {
                daw.Configuration.ProxyCreationEnabled = false;
                var listLoaiXe = (from lx in daw.LoaiXes
                                  where lx.IsDeleted == false
                                  select lx);
                return new JsonResult { Data = listLoaiXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
            }
            return new JsonResult { Data = null , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //List<LoaiXe> listLoaiXe = new List<LoaiXe>();
            //try
            //{
            //    using (DoAnWebEntities daw = new DoAnWebEntities())
            //    {
            //        listLoaiXe = daw.LoaiXes.Where(x => x.IsDeleted == false).ToList();
            //    }
            //}
            //catch (Exception)
            //{

            //}
            //return new JsonResult { Data = listLoaiXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
        #region phần CRUD loại xe
        public ActionResult LoaiXeIndex()
        {
            return View();
        }
        public ActionResult ThemLoaiXe()
        {
            return View();
        }
        // phần loại xe
        [HttpPost]
        public JsonResult ThemLoaiXe(LoaiXe loaiXe)
        {
            string message = "";
            var checkLoaiXe = daw.LoaiXes.Where(x => x.TenLoaiXe.Trim().ToUpper() == loaiXe.TenLoaiXe.Trim().ToUpper()).FirstOrDefault();
            if(checkLoaiXe != null)
            {
                message = "Loại xe này đã có trong dữ liệu";
            }
            else
            {
                loaiXe.IdLoaiXe = Guid.NewGuid();
                loaiXe.CreatedDate = DateTime.Now;
                loaiXe.IsActive = true;
                loaiXe.IsDeleted = false;
                loaiXe.SoLuong = 0;
                loaiXe.UpdatedDate = DateTime.Now;
                loaiXe.MauXe = "";
                daw.LoaiXes.Add(loaiXe);
                daw.SaveChanges();
                message = "Success";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult CapNhatLoaiXe(string LoaiXe)
        {
            string url = Request.Url.AbsoluteUri;
            string[] ArrayUrl = url.Split('/');
            int count = ArrayUrl.Length;
            if (LoaiXe == null)
            {
                LoaiXe = ArrayUrl[count - 1];
            }
            Guid IdXeCapNhat = new Guid(LoaiXe);
            LoaiXe xeUpdate = daw.LoaiXes.Where(x => x.IdLoaiXe == IdXeCapNhat && x.IsDeleted == false).FirstOrDefault();
            if (xeUpdate != null)
            {
                List<KhoXe> khoxe = daw.KhoXes.Where(x => x.IsDeleted == false).ToList();
                List<LoaiXe> loaixe = daw.LoaiXes.Where(x => x.IsDeleted == false).ToList();
                List<NhaCungCap> ncc = daw.NhaCungCaps.Where(x => x.IsDeleted == false).ToList();
                ViewBag.khoxe = khoxe;
                ViewBag.loaixe = loaixe;
                ViewBag.ncc = ncc;
            }
            ViewBag.xeUpdate = xeUpdate;
            return View();
        }
        [HttpPost]
        public string CapNhatLoaiXe(LoaiXe LoaiXe)
        {
            try
            {
                LoaiXe data = daw.LoaiXes.Where(x => x.IdLoaiXe == LoaiXe.IdLoaiXe).FirstOrDefault();
                NguoiDung nd = daw.NguoiDungs.Where(x => x.TenNguoiDung == "admin" && x.IsDeleted == false).FirstOrDefault();
                data.TenLoaiXe = LoaiXe.TenLoaiXe;
                data.UpdatedDate = LoaiXe.UpdatedDate;
                daw.LoaiXes.Attach(data);
                daw.Entry(data).State = EntityState.Modified;
                daw.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                throw;
                return "";
            }
        }

        //phần cập nhật kho
        public ActionResult CapNhatKho(string IdKho)
        {
            string url = Request.Url.AbsoluteUri;
            string[] ArrayUrl = url.Split('/');
            int count = ArrayUrl.Length;
            if (IdKho == null)
            {
                IdKho = ArrayUrl[count - 1];
            }
            Guid IdKhoCapNhat = new Guid(IdKho);
            KhoXe KhoUpdate = daw.KhoXes.Where(x => x.IdKhoXe == IdKhoCapNhat && x.IsDeleted == false).FirstOrDefault();
            if (KhoUpdate != null)
            {
                ViewBag.KhoUpdate = KhoUpdate;
            }
            return View();
        }
        [HttpPost]
        public string CapNhatKho(KhoXe KhoXe)
        {
            try
            {
                KhoXe data = daw.KhoXes.Where(x => x.IdKhoXe == KhoXe.IdKhoXe).FirstOrDefault();
                NguoiDung nd = daw.NguoiDungs.Where(x => x.TenNguoiDung == "admin" && x.IsDeleted == false).FirstOrDefault();
                data.TenKho = KhoXe.TenKho;
                data.DiaChi = KhoXe.DiaChi;
                daw.KhoXes.Attach(data);
                daw.Entry(data).State = EntityState.Modified;
                daw.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                throw;
                return "";
            }
        }


        #endregion
        #region phần về kho xe
        public ActionResult KhoXeIndex()
        {
            daw.Configuration.ProxyCreationEnabled = false;
            return View();
        }
        [HttpGet]
        public JsonResult InitalKhoXe()
        {
            try
            {
                daw.Configuration.ProxyCreationEnabled = false;
                var listKhoXe = (from kx in daw.KhoXes
                                  where kx.IsDeleted == false
                                  select kx);
                return new JsonResult { Data = listKhoXe, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {

            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult ThemKhoXe()
        {
            daw.Configuration.ProxyCreationEnabled = false;
            return View();
        }
        [HttpPost]
        public JsonResult ThemKhoXe(KhoXe khoXe)
        {
            string message = "";
            var checkKhoXe = daw.KhoXes.Where(x => x.TenKho.Trim().ToUpper() == khoXe.TenKho.Trim().ToUpper()).FirstOrDefault();
            if (checkKhoXe != null)
            {
                message = "Kho xe này đã có trong dữ liệu";
            }
            else
            {
                khoXe.IdKhoXe = Guid.NewGuid();
                khoXe.IsDeleted = false;
                khoXe.TinhTrang = true;
                daw.KhoXes.Add(khoXe);
                daw.SaveChanges();
                message = "Success";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
        #region Sửa xóa xe
        public ActionResult CapNhatXe(string IdXe)
        {
            string url = Request.Url.AbsoluteUri;
            string[] ArrayUrl = url.Split('/');
            int count = ArrayUrl.Length;
            if (IdXe == null)
            {
                IdXe = ArrayUrl[count - 1];
            }
            Guid IdXeCapNhat = new Guid(IdXe);
            Xe xeUpdate = daw.Xes.Where(x => x.IdXe == IdXeCapNhat && x.IsDeleted == false).FirstOrDefault();
            if(xeUpdate != null)
            {
                List<KhoXe> khoxe = daw.KhoXes.Where(x=>x.IsDeleted == false).ToList();
                List<LoaiXe> loaixe = daw.LoaiXes.Where(x => x.IsDeleted == false).ToList();
                List<NhaCungCap> ncc = daw.NhaCungCaps.Where(x=>x.IsDeleted == false).ToList();
                ViewBag.khoxe = khoxe;
                ViewBag.loaixe = loaixe;
                ViewBag.ncc = ncc;
            }
            ViewBag.xeUpdate = xeUpdate;
            return View();
        }
        [HttpPost]
        public string CapNhatXe(Xe xe)
        {
            try
            {
                Xe data = daw.Xes.Where(x => x.IdXe == xe.IdXe).FirstOrDefault();
                NguoiDung nd = daw.NguoiDungs.Where(x => x.TenNguoiDung == "admin" && x.IsDeleted == false).FirstOrDefault();
                data.IdKhoXe = xe.IdKhoXe;
                data.ChiTiet = xe.ChiTiet;
                data.GiaNiemYetXe = xe.GiaNiemYetXe;
                data.GiaVonXe = xe.GiaVonXe;
                data.IdNhaCungCap = xe.IdNhaCungCap;
                data.NgayNhap = xe.NgayNhap;
                data.TenXe = xe.TenXe;
                data.UpdatedBy = nd.IdNguoiDung;
                data.UpdatedDate = xe.UpdatedDate;
                daw.Xes.Attach(data);
                daw.Entry(data).State = EntityState.Modified;
                daw.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                throw;
                return "";
            }
            
        }
        [HttpPost]
        public JsonResult DeleteXe(string Id)
        {
            return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
    }
}
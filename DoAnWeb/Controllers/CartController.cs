using DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DoAnWeb.Controllers
{
    public class CartController : Controller
    {
        DoAnWebEntities daw = new DoAnWebEntities();
        private string CartSession = "CartSession";
        private string AccountSession = "AccountSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(Guid SanPhamID, int SoLuong)
        {
            var xe = daw.Xes.Where(x => x.IdXe == SanPhamID).FirstOrDefault();
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(e => e.SanPham.IdXe == SanPhamID))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.IdXe == SanPhamID)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                }
                else
                {
                    // tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.SanPham = xe;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                // tạo mới đối tượng cart item
                var item = new CartItem();
                item.SanPham = xe;
                item.SoLuong = SoLuong;
                var list = new List<CartItem>();
                list.Add(item);
                // gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var ssCart = (List<CartItem>)Session[CartSession];
            foreach (var item in ssCart)
            {
                var jsonItem = jsonCart.Where(j => j.SanPham.IdXe == item.SanPham.IdXe).FirstOrDefault();
                if (jsonItem != null)
                    item.SoLuong = jsonItem.SoLuong;
            }
            Session[CartSession] = ssCart;
            return Json(new { status = true });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new { status = true });
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            Guid idXe = Guid.Parse(id);
            var ssCart = (List<CartItem>)Session[CartSession];
            var xe = ssCart.RemoveAll(x => x.SanPham.IdXe == idXe);
            Session[CartSession] = ssCart;
            return Json(new { status = true });
        }

        public ActionResult Payment()
        {
            try
            {
                var acc = Session[AccountSession];
                if (acc != null)
                {
                    double totalQty = 0, totalAmount = 0;
                    // lấy giỏ hàng
                    var ssCart = (List<CartItem>)Session[CartSession];
                    // lấy user đăng nhập
                    var ssAcc = (List<NguoiDung>)Session[AccountSession];

                    #region Save giohang
                    var order = new GioHang();
                    order.IdGioHang = Guid.NewGuid();
                    order.IdKhachHang = ssAcc[0].IdNguoiDung;
                    order.IsDeleted = false;
                    order.TinhTrang = false;
                    order.CreatedDate = DateTime.Now;
                    order.UpdatedDate = DateTime.Now;

                    foreach (var item in ssCart)
                    {
                        var orderD = new CTGioHang();
                        orderD.IdGioHang = order.IdGioHang;
                        //orderD.IdOrder = order.ID;
                        orderD.IdMaXe = item.SanPham.IdXe;
                        orderD.Gia = item.SanPham.GiaNiemYetXe;
                        orderD.SoLuong = item.SoLuong;
                        orderD.ThanhTien = (item.SanPham.GiaNiemYetXe * item.SoLuong);
                        orderD.IsDeleted = false;
                        orderD.TinhTrang = false;
                        orderD.CreatedDate = DateTime.Now;
                        orderD.UpdatedDate = DateTime.Now;
                        daw.CTGioHangs.Add(orderD);
                        totalQty += (double)item.SoLuong;
                        totalAmount += (double)(item.SanPham.GiaNiemYetXe * item.SoLuong);
                    }
                    order.TongSoLuong = Convert.ToInt32(totalQty);
                    order.TongThanhTien = totalAmount;
                    daw.GioHangs.Add(order);
                    #endregion

                    //#region Save PhieuThu
                    //var invoice = new HoaDonThu();
                    //invoice.MaHoaDonThu = string.Format("{0}{1:yyyyMMddhhmmss}", "THU", DateTime.Now);
                    //invoice.KhachHang = ssAcc[0].IdNguoiDung;
                    //invoice.NgayThu = DateTime.Now;
                    //invoice.TongSoLuong = Convert.ToInt32(totalQty);
                    //invoice.TongTien = totalAmount;
                    //invoice.IsDeleted = false;
                    //invoice.TinhTrang = true;
                    //invoice.CreatedDate = DateTime.Now;
                    //invoice.UpdatedDate = DateTime.Now;
                    //invoice.CreatedBy = ssAcc[0].IdNguoiDung;
                    //invoice.UpdatedBy = ssAcc[0].IdNguoiDung;
                    //daw.HoaDonThus.Add(invoice);
                    //#endregion

                    #region cập nhật sl bảng xe, tình trạng loaixe
                    foreach (var item in ssCart)
                    {
                        var xe = daw.Xes.Where(x => x.IdXe == item.SanPham.IdXe).FirstOrDefault();
                        if (xe != null)
                        {
                            var loaixe = daw.LoaiXes.Where(l => l.IdLoaiXe == xe.MaLoaiXe).FirstOrDefault();
                            if (loaixe != null)
                            {
                                // cập nhật lại sl cho bảng loại xe
                                loaixe.SoLuong -= item.SoLuong;
                                daw.LoaiXes.Attach(loaixe);
                            }
                            // cập nhật lại tình trạng cho bảng xe
                            xe.TinhTrang = "SOLD";
                            daw.Xes.Attach(xe);
                        }
                    }
                    #endregion
                    // xóa giỏ hàng
                    Session[CartSession] = null;

                    var user = daw.NguoiDungs.Where(l => l.IdNguoiDung == order.IdKhachHang).FirstOrDefault();
                    ViewBag.Name = user.TenNguoiDung;
                    ViewBag.Phone = user.SoDienThoai;
                    ViewBag.Email = user.Email;
                    daw.SaveChanges();
                    return View(ssCart);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Success()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
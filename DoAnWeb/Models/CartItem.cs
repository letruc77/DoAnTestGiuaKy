using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    [Serializable]
    public class CartItem
    {
        public Xe SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}
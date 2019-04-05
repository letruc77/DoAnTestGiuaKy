using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    [Serializable]
    public class Account
    {
        public System.Guid IdNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
    }
}
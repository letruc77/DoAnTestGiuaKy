//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTGioHang
    {
        public System.Guid IdGioHang { get; set; }
        public System.Guid IdMaXe { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> Gia { get; set; }
    
        public virtual GioHang GioHang { get; set; }
        public virtual Xe Xe { get; set; }
    }
}

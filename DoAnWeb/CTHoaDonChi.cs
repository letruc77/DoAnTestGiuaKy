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
    
    public partial class CTHoaDonChi
    {
        public System.Guid MaHoaDonChi { get; set; }
        public System.Guid MaXe { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual HoaDonChi HoaDonChi { get; set; }
        public virtual Xe Xe { get; set; }
    }
}

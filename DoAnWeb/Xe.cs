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
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.CTGioHangs = new HashSet<CTGioHang>();
            this.CTHoaDonChis = new HashSet<CTHoaDonChi>();
            this.CTHoaDonThus = new HashSet<CTHoaDonThu>();
        }
    
        public System.Guid IdXe { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public Nullable<System.Guid> MaLoaiXe { get; set; }
        public Nullable<System.Guid> IdKhoXe { get; set; }
        public string ChiTiet { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<System.DateTime> NgayXuat { get; set; }
        public Nullable<System.Guid> OfUser { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<int> SoLuotXem { get; set; }
        public Nullable<System.Guid> IdNhaCungCap { get; set; }
        public Nullable<double> GiaVonXe { get; set; }
        public Nullable<double> GiaNiemYetXe { get; set; }
        public string TenXe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGioHang> CTGioHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonChi> CTHoaDonChis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonThu> CTHoaDonThus { get; set; }
        public virtual KhoXe KhoXe { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}

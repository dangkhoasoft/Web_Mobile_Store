//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mobile_store.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_DonHang()
        {
            this.tb_CTDonHang = new HashSet<tb_CTDonHang>();
        }
    
        public int MaDH { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<System.DateTime> NgayGiao { get; set; }
        public string DaThanToan { get; set; }
        public string TinhTrangGiao { get; set; }
        public Nullable<int> MaKH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CTDonHang> tb_CTDonHang { get; set; }
        public virtual tb_KhachHang tb_KhachHang { get; set; }
    }
}

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
    
    public partial class tb_LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_LoaiSanPham()
        {
            this.tb_DienThoai = new HashSet<tb_DienThoai>();
        }
    
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_DienThoai> tb_DienThoai { get; set; }
    }
}

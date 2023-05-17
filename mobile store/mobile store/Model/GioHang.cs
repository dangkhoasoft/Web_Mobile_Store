using mobile_store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace mobile_store.Model
{
    public class GioHang
    {
        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        public int iMaDT { get; set; }
        public string sTenDT { get; set; }
        public string HinhAnh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
        //Hàm tạo cho giỏ hàng 
        public GioHang(int MaDT)
        {
            iMaDT = MaDT;
            tb_DienThoai dienthoai = db.tb_DienThoai.Single(n => n.MaDienThoai == MaDT);
            sTenDT = dienthoai.TenDienThoai;
            HinhAnh = dienthoai.HinhSP1;
            DonGia = double.Parse(dienthoai.GiaBan.ToString());
            SoLuong = 1;
        }
    }
}
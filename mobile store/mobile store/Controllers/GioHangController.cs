using mobile_store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobile_store.Controllers
{
    public class GioHangController : Controller
    {
        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        //Get Gio Hang
        public List<GioHang> GetGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tạo list giỏ hàng 
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;
        }
        //Thêm giỏ hàng 
        public ActionResult ThemGioHang(int MaDT, string strUrl)
        {
            tb_DienThoai dienthoai = db.tb_DienThoai.SingleOrDefault(n => n.MaDienThoai == MaDT);
            if (dienthoai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng 
            List<GioHang> lstGioHang = GetGioHang();
            //Kiểm tra sách này đã tồn tại trong session[giohang] chưa
            GioHang gh = lstGioHang.Find(n => n.iMaDT == MaDT);
            if (gh == null)
            {
                gh = new GioHang(MaDT);
                //aDD them san pham moi 
                lstGioHang.Add(gh);
                return Redirect(strUrl);
            }
            else
            {
                gh.SoLuong++;
                return Redirect(strUrl);
            }


        }
        // Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int MaDT, FormCollection form)
        {
            //Kiểm tra mã sản phẩm ĐIện Thoại 
            tb_DienThoai dienthoai = db.tb_DienThoai.SingleOrDefault(n => n.MaDienThoai == MaDT);
            if (dienthoai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = GetGioHang();
            //Kiểm tra sản phẩm có tồn tại trong session
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaDT == MaDT);
            if (gh != null)
            {
                gh.SoLuong = int.Parse(form["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int MaDT)
        {
            //Kiểm tra mã sản phẩm ĐIện Thoại 
            tb_DienThoai dienthoai = db.tb_DienThoai.SingleOrDefault(n => n.MaDienThoai == MaDT);
            if (dienthoai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = GetGioHang();
            GioHang gh = lstGioHang.SingleOrDefault(n => n.iMaDT == MaDT);
            if (gh != null)
            {
                lstGioHang.RemoveAll(n => n.iMaDT == MaDT);


            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng 
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Shop");
            }
            List<GioHang> lstGioHang = GetGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tiền 
        private int TongSL()
        {
            int iTongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSL = lstGioHang.Sum(n => n.SoLuong);

            }
            return iTongSL;
        }
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.ThanhTien);

            }
            return iTongTien;
        }
        //tạo partial giỏ hàng 
       public ActionResult GioHangPartial()
        {
            if (TongSL() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSl = TongSL();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //xây dựng chức năng đật hàng 
        public ActionResult DatHang()
        {
            return View();
        }
    }
}
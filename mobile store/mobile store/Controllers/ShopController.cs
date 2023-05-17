using mobile_store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobile_store.Controllers
{
    public class ShopController : Controller
    {
        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        // GET: Shop
        public ActionResult Products()
        {
            return View();
        }

        // GET: Shop/Details/5
        public ActionResult Details(int MaDienThoai)
        {
            tb_DienThoai dienthoai = db.tb_DienThoai.SingleOrDefault(n => n.MaDienThoai == MaDienThoai);
            if (dienthoai == null)
            {
                //trả về trang báo lỗi 
                Response.StatusCode = 404;
                Console.WriteLine("Xin Chaof");
                return null;
            }
            ViewBag.TenLoaiSP = db.tb_LoaiSanPham.Single(n => n.MaLoaiSP == dienthoai.MaLoai).TenLoaiSP;
            ViewBag.TenNSX = db.tb_NhaSanXuat.Single(n => n.MaNSX == dienthoai.MaNSX).TenNSX;
            return View(dienthoai);
        }

        // GET: Shop/Create
        public ActionResult ShoppingCart()
        {
            return View();
        }

        // POST: Shop/Create
       
        public ActionResult Payment()
        {
            
            
                return View();
            
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult _Menu()
        //{
        //    var IsLoaiSanPham = db.tb_LoaiSanPham.ToList();
        //    return View(IsLoaiSanPham);
        //}
        

    }
}

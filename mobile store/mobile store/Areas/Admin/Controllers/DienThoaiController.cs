using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mobile_store.Model;

namespace mobile_store.Areas.Admin.Controllers
{
    public class DienThoaiController : Controller
    {
        private Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();

        // GET: Admin/DienThoai
        public ActionResult Index()
        {
            var tb_DienThoai = db.tb_DienThoai.Include(t => t.tb_LoaiSanPham).Include(t => t.tb_NhaSanXuat);
            return View(tb_DienThoai.ToList());
        }

        // GET: Admin/DienThoai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DienThoai tb_DienThoai = db.tb_DienThoai.Find(id);
            if (tb_DienThoai == null)
            {
                return HttpNotFound();
            }
            return View(tb_DienThoai);
        }

        // GET: Admin/DienThoai/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSanPham, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MaNSX = new SelectList(db.tb_NhaSanXuat, "MaNSX", "TenNSX");
            return View();
        }

        // POST: Admin/DienThoai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDienThoai,TenDienThoai,GiaBan,Mota,MaLoai,HinhSP1,HinhSP2,HinhSP3,HinhSP4,KichThuocHinhAnh,Camera_Truoc,Camera_Sau,He_Dieu_Hanh,CPU,RAM,Bo_Nho_Trong,The_Nho,Sim,Ket_Noi,Pin,ChuThich,MaNSX,moi")] tb_DienThoai tb_DienThoai)
        {
            if (ModelState.IsValid)
            {
                db.tb_DienThoai.Add(tb_DienThoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.tb_LoaiSanPham, "MaLoaiSP", "TenLoaiSP", tb_DienThoai.MaLoai);
            ViewBag.MaNSX = new SelectList(db.tb_NhaSanXuat, "MaNSX", "TenNSX", tb_DienThoai.MaNSX);
            return View(tb_DienThoai);
        }

        // GET: Admin/DienThoai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DienThoai tb_DienThoai = db.tb_DienThoai.Find(id);
            if (tb_DienThoai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSanPham, "MaLoaiSP", "TenLoaiSP", tb_DienThoai.MaLoai);
            ViewBag.MaNSX = new SelectList(db.tb_NhaSanXuat, "MaNSX", "TenNSX", tb_DienThoai.MaNSX);
            return View(tb_DienThoai);
        }

        // POST: Admin/DienThoai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDienThoai,TenDienThoai,GiaBan,Mota,MaLoai,HinhSP1,HinhSP2,HinhSP3,HinhSP4,KichThuocHinhAnh,Camera_Truoc,Camera_Sau,He_Dieu_Hanh,CPU,RAM,Bo_Nho_Trong,The_Nho,Sim,Ket_Noi,Pin,ChuThich,MaNSX,moi")] tb_DienThoai tb_DienThoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DienThoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSanPham, "MaLoaiSP", "TenLoaiSP", tb_DienThoai.MaLoai);
            ViewBag.MaNSX = new SelectList(db.tb_NhaSanXuat, "MaNSX", "TenNSX", tb_DienThoai.MaNSX);
            return View(tb_DienThoai);
        }

        // GET: Admin/DienThoai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DienThoai tb_DienThoai = db.tb_DienThoai.Find(id);
            if (tb_DienThoai == null)
            {
                return HttpNotFound();
            }
            return View(tb_DienThoai);
        }

        // POST: Admin/DienThoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DienThoai tb_DienThoai = db.tb_DienThoai.Find(id);
            db.tb_DienThoai.Remove(tb_DienThoai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

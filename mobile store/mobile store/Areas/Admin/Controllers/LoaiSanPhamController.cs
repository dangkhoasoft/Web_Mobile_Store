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
    public class LoaiSanPhamController : Controller
    {
        private Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();

        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            return View(db.tb_LoaiSanPham.ToList());
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSanPham tb_LoaiSanPham = db.tb_LoaiSanPham.Find(id);
            if (tb_LoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_LoaiSanPham);
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSP,TenLoaiSP")] tb_LoaiSanPham tb_LoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.tb_LoaiSanPham.Add(tb_LoaiSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_LoaiSanPham);
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSanPham tb_LoaiSanPham = db.tb_LoaiSanPham.Find(id);
            if (tb_LoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_LoaiSanPham);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSP,TenLoaiSP")] tb_LoaiSanPham tb_LoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_LoaiSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_LoaiSanPham);
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSanPham tb_LoaiSanPham = db.tb_LoaiSanPham.Find(id);
            if (tb_LoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_LoaiSanPham);
        }

        // POST: Admin/LoaiSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_LoaiSanPham tb_LoaiSanPham = db.tb_LoaiSanPham.Find(id);
            db.tb_LoaiSanPham.Remove(tb_LoaiSanPham);
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

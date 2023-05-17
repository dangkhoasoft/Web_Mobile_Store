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
    public class tb_NhaSanXuatController : Controller
    {
        private Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();

        // GET: Admin/tb_NhaSanXuat
        public ActionResult Index()
        {
            return View(db.tb_NhaSanXuat.ToList());
        }

        // GET: Admin/tb_NhaSanXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhaSanXuat tb_NhaSanXuat = db.tb_NhaSanXuat.Find(id);
            if (tb_NhaSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhaSanXuat);
        }

        // GET: Admin/tb_NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tb_NhaSanXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNSX,TenNSX,DiaChi,DienThoai")] tb_NhaSanXuat tb_NhaSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.tb_NhaSanXuat.Add(tb_NhaSanXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_NhaSanXuat);
        }

        // GET: Admin/tb_NhaSanXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhaSanXuat tb_NhaSanXuat = db.tb_NhaSanXuat.Find(id);
            if (tb_NhaSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhaSanXuat);
        }

        // POST: Admin/tb_NhaSanXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNSX,TenNSX,DiaChi,DienThoai")] tb_NhaSanXuat tb_NhaSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NhaSanXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_NhaSanXuat);
        }

        // GET: Admin/tb_NhaSanXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhaSanXuat tb_NhaSanXuat = db.tb_NhaSanXuat.Find(id);
            if (tb_NhaSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhaSanXuat);
        }

        // POST: Admin/tb_NhaSanXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_NhaSanXuat tb_NhaSanXuat = db.tb_NhaSanXuat.Find(id);
            db.tb_NhaSanXuat.Remove(tb_NhaSanXuat);
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

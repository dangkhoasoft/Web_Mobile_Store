using mobile_store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobile_store.Model;
namespace Web_Ban_Dien_Thoai.Controllers
{
    public class UserController : Controller
    {
        // GET: NguoiDung
        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        public ActionResult LoginAccount()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(tb_KhachHang kh)
        {
            var check = db.tb_KhachHang.Where(s => s.Email == kh.Email && s.MatKhau == kh.MatKhau).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai tài khoản hoặc mật khẩu!";
                return View("Login");
            }
            else
            {
                var test = db.tb_KhachHang.FirstOrDefault(s => s.Email == kh.Email);
                if (test.Email == "nhanvien.admin" && test.MatKhau == "123123")// nếu là admin chuyển sang trang admin
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else// ngược lại chuyển qua trang người dùng
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    Session["Email"] = kh.Email;
                    Session["MatKhau"] = kh.MatKhau;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterUser(tb_KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu vào khách hàng 
                db.tb_KhachHang.Add(kh);
                //Lưu vào cơ sở dữ liệu 
                db.SaveChanges();
            }

            return View();
        }
        public ActionResult ProfileUser()
        {
            return View();
        }
    }
}
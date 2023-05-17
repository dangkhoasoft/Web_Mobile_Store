
using mobile_store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mobile_store.Controllers
{
    public class HomeController : Controller
    {
        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        public ActionResult index()
        {
            return View();
        }
        public PartialViewResult ProductMain()
        {
            var IsDienThoai = db.tb_DienThoai.ToList();
            return PartialView(IsDienThoai);
        }
    }
}
    
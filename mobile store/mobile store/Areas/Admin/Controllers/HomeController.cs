using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobile_store.Model;
using PagedList.Mvc;
using PagedList;
using System.Web.UI;

namespace mobile_store.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        Sell_Mobile_1Entities db = new Sell_Mobile_1Entities();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 18;
            return View(db.tb_DienThoai.ToList().OrderBy(n => n.TenDienThoai).ToPagedList(pageNumber, pageSize));
           
        }
    }
}
using ShopAoThung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAoThung.Controllers
{
    public class ProductController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _aoThungNam()
        {
            var list = db.Products.Where(m => m.status == 1 && m.catid == 10).Take(4).ToList();
            return View("_product", list);
        }
        public ActionResult _aoThungNu()
        {
            return View();
        }
        public ActionResult _phuKien()
        {
            return View();
        }

    }
}
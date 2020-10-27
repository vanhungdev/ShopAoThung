using ShopAoThung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAoThung.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules

        private BookstoreDbContext db = new BookstoreDbContext();
        public ActionResult _header()
        {
            return View("_header");
        }
        public ActionResult _mainmenu()
        {
            return View("_mainmenu");
        }
        public ActionResult _slider()
        {
            return View("_slider");
        }
        public ActionResult _footer()
        {
            return View("_footer");
        }
    }
}
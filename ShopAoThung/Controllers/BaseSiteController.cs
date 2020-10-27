using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAoThung.Controllers
{
    public class BaseSiteController : Controller
    {
        // GET: BaseSite
        public ActionResult Index()
        {
            return View();
        }
    }
}
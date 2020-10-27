using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopAoThung
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Session["cart"] = "";
            Session["favoriteProduct"] = "";
            Session["Admin_id"] = "";
            Session["Admin_user"] = "";
            Session["Admin_fullname"] = "";
            Session["Message"] = "";
            Session["id"] = "";
            Session["user"] = "";
            Session["OrderId"] = "";
        }
    }
}

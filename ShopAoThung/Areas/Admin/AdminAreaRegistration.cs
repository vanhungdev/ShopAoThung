using System.Web.Mvc;

namespace ShopAoThung.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }


        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
            "Admin_contact",
            "Admin/contact",
            new { Controller = "contact", action = "index", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
        );
            context.MapRoute(
              "Admin_product",
              "Admin/product",
              new { Controller = "Products", action = "index", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
          );
            context.MapRoute(
           "Admin_clint_edit",
           "admin/info/{id}",
           new { Controller = "Dashboard", action = "Edit", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
     );
            context.MapRoute(
                "Admin_login",
                "Admin/login",
                new { Controller = "auth", action = "login", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_logout",
                "Admin/logout",
                new { Controller = "auth", action = "logout", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
            );

            context.MapRoute(
           "statistics",
           "Admin/statistics",
           new { Controller = "Dashboard", action = "statistics", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
       );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
                new[] { "ShopAoThung.Areas.Admin.Controllers" }
            );
        }
    }
}
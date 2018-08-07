using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                defaults: new { controller = "Product", action = "List", page = 1, category = (string)null }
            );

            routes.MapRoute(
                null,
                "Page{page}",
                defaults: new { controller = "Product", action = "List",
                    category = (string)null }
            );

            routes.MapRoute(
                null,
                "{category}",
                defaults: new { controller = "Product", action = "List", page=1 }
            );

            routes.MapRoute(
                null,
                "{category}/Page{page}",
                defaults: new { controller = "Product", action = "List" }
            );

            routes.MapRoute(
                name: null,
                url: "Page{Page}",
                defaults: new { controller = "Product", action = "List" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}

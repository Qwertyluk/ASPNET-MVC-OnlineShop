using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductInformation",
                url: "product-{id}",
                defaults: new { controller = "Product", action = "ShowInformation" }
                );

            routes.MapRoute(
                name: "staticSites",
                url: "static/{name}.html",
                defaults: new { controller = "Home", action = "StaticSites" }
                ) ;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
            //defaults: new { controller = "Default", action = "KitBase", id = UrlParameter.Optional }
            defaults: new { controller = "Default", action = "Test", id = UrlParameter.Optional }
            );
        }
    }
}

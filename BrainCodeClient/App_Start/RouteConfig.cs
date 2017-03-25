using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BrainCodeClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AlleCoZnalazlo",
                url: "AlleCoZnalazlo",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "AlleJakNazwac",
                url: "AlleJakNazwac",
                defaults: new { controller = "Home", action = "Naming" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

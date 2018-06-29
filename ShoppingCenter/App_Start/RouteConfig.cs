using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCenter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Main", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Order",
               url: "{controller}/{action}/{id}/{quantity}",
               defaults: new { controller = "Home", action = "Order", id = UrlParameter.Optional, quantity = UrlParameter.Optional}
           );

            routes.MapRoute(
              name: "CompletedOrder",
              url: "{controller}/{action}/{methodPayment}",
              defaults: new { controller = "Home", action = "CompletedOrder", methodPayment = UrlParameter.Optional , reception=UrlParameter.Optional}
          );

        }
    }
}

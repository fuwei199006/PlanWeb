using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Plain.CMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ControllerHtml",
               url: "PlainCms/{controller}.html",
               defaults: new { controller = "CmsHome", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "ActionHtml",
              url: "PlainCms/{controller}/{cction}.html",
              defaults: new { controller = "CmsHome", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "DetaiHtml",
                url: "PlainCms/{controller}/{action}/{id}.html",
                 defaults: new { controller = "CmsHome", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Action",
             url: "PlainCms/{controller}/{action}",
             defaults: new { controller = "CmsHome", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Detai",
                url: "PlainCms/{controller}/{action}/{id}",
                  defaults: new { controller = "CmsHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

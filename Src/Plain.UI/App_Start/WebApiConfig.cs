using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Plain.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //SetDefaultContentHeaders();.Add(new QueryStringMapping("datatype", "json", "application/json"));
            //config.Formatters.JsonFormatter.SetDefaultContentHeaders();
            //config.Formatters.JsonFormatter.MediaTypeMappings
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using Newtonsoft.Json.Serialization;
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
            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Remove the JSON formatter
            //config.Formatters.Remove(config.Formatters.JsonFormatter);



            //http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness
            //There is a more general solution: you can configure the Json Serializer to ignore the[Serializable] attribute, so that you don't have to change the attributes in your classes.
            //
            //You should make this configuration change in the application start, i.e. in Global.asax Application_Start event:

            //var serializerSettings =
            //  GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            //        var contractResolver =
            //  (DefaultContractResolver)serializerSettings.ContractResolver;
            //        contractResolver.IgnoreSerializableAttribute = true;
            //        You can also make other changes to the Json serialization, like specifying formats for serializing dates, and many other things.

            //This will only apply to the Web API JSON serialization. The other serializations in the app (Web API XML serialization, MVC JsonResult...) won't be affected by this setting.
            var serializerSettings =GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "PlainApi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Plain.BLL;
using Plan.UI;
using System.Net.Http.Formatting;
using Autofac.Integration.WebApi;
using System.Security;
 
namespace Plain.UI
{

    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof(IBaseService<>).Assembly)
              .Where(t => typeof(BaseService<>).IsClass && !t.IsAbstract)
              .AsImplementedInterfaces().InstancePerRequest().InstancePerLifetimeScope();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver for Web API.
            builder.RegisterFilterProvider();
            
            var container = builder.Build();

            //webApi注入
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            //MVC注入
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //var error = Server.GetLastError();
            //Response.ContentType = "text/html;";
            //var httpError = error as HttpException;
            //var statusCode = httpError?.GetHttpCode() ?? 500;
            //var errorMsg = error.Message;
            //var routeData = new RouteData();
            //routeData.Values["controller"] = "Home";
            //routeData.Values["action"] = "TError";
            //routeData.Values["area"] = "";
            //routeData.Values["code"] = statusCode;
            //routeData.Values["error"] = errorMsg;
            //IController errorManager = new BaseController();
            //HttpContextWrapper wrapper = new HttpContextWrapper(Context);
            //Server.ClearError();
            //var rc = new RequestContext(wrapper, routeData);
            //errorManager.Execute(rc);
        }
        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
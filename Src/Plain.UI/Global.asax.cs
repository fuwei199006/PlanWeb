using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Framework.BLL;
using Plain.BLL;
using Plain.BLL.LoginService;
using Plan.UI;
using Plain.Dao;
using Plain.UI.Controllers;

namespace Plain.UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(typeof(IBaseService<>).Assembly)
                .Where(t => typeof(BaseService<>).IsClass && !t.IsAbstract)
                .AsImplementedInterfaces().InstancePerRequest().InstancePerLifetimeScope();


            builder.RegisterFilterProvider();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //开始注入

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

            Exception exception = Server.GetLastError();
            Response.Clear();
           var statusCode = (exception is HttpException)?(exception as HttpException).GetHttpCode():500;
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Home");
            switch (statusCode)
            {
                case 404:
                    // Page not found.  
                    routeData.Values.Add("action", "Error");
                    break;
                case 500:
                    // Server error.  
                    routeData.Values.Add("action", "Error");
                    break;
            }
            // Pass exception details to the target error View.  
            routeData.Values.Add("error", exception.Message);
            routeData.Values.Add("code", statusCode);
            // Clear the error on server.  
            Server.ClearError();
            // Call target Controller and pass the routeData.  
            IController errorController = new BaseController();
            Context.Response.ContentType = "text/html; charset=utf-8";
            errorController.Execute(new RequestContext(
           new HttpContextWrapper(Context), routeData));

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
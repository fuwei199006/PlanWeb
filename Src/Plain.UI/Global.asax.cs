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
using System.Data.SqlClient;
using Core.Config;
using Core.Exception;
using Plain.BLL.ConfigService;

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
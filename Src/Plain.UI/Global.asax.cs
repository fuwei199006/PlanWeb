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
            builder.RegisterAssemblyTypes(typeof(BaseService<>).Assembly)
                .Where(t => typeof(BaseService<>).IsClass&&!t.IsAbstract)
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

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
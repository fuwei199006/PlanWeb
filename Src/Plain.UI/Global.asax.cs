using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Plan.UI;

namespace Plain.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder=new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof (MvcApplication).Assembly)
                .Where(r => (r.Name.EndsWith("Service")) && !r.IsAbstract).InstancePerLifetimeScope().AsImplementedInterfaces();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

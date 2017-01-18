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
using System.Collections;

namespace Plain.UI
{

    public class Global : HttpApplication
    {
        //MethodInfo[] _eventHandlerMethods  ;
        //private void ReflectOnApplicationType()
        //{
        //    ArrayList handlers = new ArrayList();
        //    MethodInfo[] methods;

        //    //Debug.Trace("PipelineRuntime", "ReflectOnApplicationType");

        //    // get this class methods
        //    methods = this.GetType().BaseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        //    foreach (MethodInfo m in methods)
        //    {
        //        if (ReflectOnMethodInfoIfItLooksLikeEventHandler(m))
        //            handlers.Add(m);
        //    }

        //    // get base class private methods (GetMethods would not return those)
        //    Type baseType = this.GetType().BaseType.BaseType;
        //    if (baseType != null && baseType != typeof(HttpApplication))
        //    {
        //        methods = baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        //        foreach (MethodInfo m in methods)
        //        {
        //            if (m.IsPrivate && ReflectOnMethodInfoIfItLooksLikeEventHandler(m))
        //                handlers.Add(m);
        //        }
        //    }
        //    _eventHandlerMethods = new MethodInfo[handlers.Count];
        //    // remember as an array
        //    _eventHandlerMethods = new MethodInfo[handlers.Count];
        //    for (int i = 0; i < _eventHandlerMethods.Length; i++)
        //        _eventHandlerMethods[i] = (MethodInfo)handlers[i];
        //}

        private bool ReflectOnMethodInfoIfItLooksLikeEventHandler(MethodInfo m)
        {
            if (m.ReturnType != typeof(void))
                return false;

            // has to have either no args or two args (object, eventargs)
            ParameterInfo[] parameters = m.GetParameters();

            switch (parameters.Length)
            {
                case 0:
                    // ok
                    break;
                case 2:
                    // param 0 must be object
                    if (parameters[0].ParameterType != typeof(System.Object))
                        return false;
                    // param 1 must be eventargs
                    if (parameters[1].ParameterType != typeof(System.EventArgs) &&
                        !parameters[1].ParameterType.IsSubclassOf(typeof(System.EventArgs)))
                        return false;
                    // ok
                    break;

                default:
                    return false;
            }

            // check the name (has to have _ not as first or last char)
            String name = m.Name;
            int j = name.IndexOf('_');
            if (j <= 0 || j > name.Length - 1)
                return false;

            // special pseudo-events
            //if (StringUtil.EqualsIgnoreCase(name, "Application_OnStart") ||
            //    StringUtil.EqualsIgnoreCase(name, "Application_Start"))
            //{
            //    _onStartMethod = m;
            //    _onStartParamCount = parameters.Length;
            //}
            //else if (StringUtil.EqualsIgnoreCase(name, "Application_OnEnd") ||
            //         StringUtil.EqualsIgnoreCase(name, "Application_End"))
            //{
            //    _onEndMethod = m;
            //    _onEndParamCount = parameters.Length;
            //}
            //else if (StringUtil.EqualsIgnoreCase(name, "Session_OnEnd") ||
            //         StringUtil.EqualsIgnoreCase(name, "Session_End"))
            //{
            //    _sessionOnEndMethod = m;
            //    _sessionOnEndParamCount = parameters.Length;
            //}

            return true;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //ReflectOnApplicationType();
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
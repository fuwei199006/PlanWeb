using System.Reflection;
using Core.Cache;
using Framework.Utility;

namespace Core.Service
{
    public abstract class ServiceFactory
    {
        public abstract T CreateService<T>() where T : class;
    }

    public class ResfServiceFactory : ServiceFactory
    {
        public override T CreateService<T>()
        {
            var interFanceName = typeof (T).Name;
            return CacheContext.Get<T>(string.Format("Service_{0}", interFanceName), () => AssemblyHelper.FindTypeByInterface<T>());
        }

    }


    public class WcfServiceFactory:ServiceFactory
    {
        public override T CreateService<T>()
        {
            var url = string.Empty;
            var proxy = WcfServiceProxy.CreateServiceProxy<T>(url);
            return proxy;
        }
    }
}

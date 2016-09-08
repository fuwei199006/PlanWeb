using System.Reflection;
using Core.Cache;
using Framework.Utility;

namespace Core.Service
{
    public abstract class ServiceFactory
    {
        public abstract T CreateService<T>() where T : class,new();
    }

    public class ResfServiceFactory : ServiceFactory
    {
        public override T CreateService<T>()
        {
            var interFanceName = typeof (T).Name;
            if (typeof(T).IsGenericType) //如果是泛型的类型
            {
                interFanceName += "_" + typeof(T).GetGenericArguments()[0].Name;
            }
            return CacheContext.Get<T>(string.Format("Service_{0}", interFanceName), () => AssemblyHelper.FindTypeByInterface<T>());
        }
    }

    public class CacheServiceFactory : ServiceFactory
    {
        public override T CreateService<T>() 
        {
            var interFanceName = typeof(T).Name;
            if (typeof (T).IsGenericType) //如果是泛型的类型
            {
                interFanceName += "_" + typeof (T).GetGenericArguments()[0].Name;
            }
 
           return CacheContext.GetItem<T>(string.Format("Service_{0}", interFanceName), () => new T());
 
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

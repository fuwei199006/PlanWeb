using System.Reflection;
using Core.Cache;
using Framework.Utility;
using System.Runtime.Remoting.Messaging;
using System;

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
            var interFanceName = typeof(T).Name;
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
            if (typeof(T).IsGenericType) //如果是泛型的类型
            {
                interFanceName += "_" + typeof(T).GetGenericArguments()[0].Name;
            }

            return CacheContext.Get<T>(string.Format("Service_{0}", interFanceName), () => AssemblyHelper.FindTypeByInterface<T>());

        }
    }
    public class WcfServiceFactory : ServiceFactory
    {
        public override T CreateService<T>()
        {
            var url = string.Empty;
            var proxy = WcfServiceProxy.CreateServiceProxy<T>(url);
            return proxy;
        }
    }

    public class ContextServiceFactory: ServiceFactory  
    {
        public override T CreateService<T>()
        {
            //当第二次执行的时候直接取出线程嘈里面的对象
            //CallContext:是线程内部唯一的独用的数据槽(一块内存空间)
            //数据存储在线程栈中
            //线程内共享一个单例
            var interFanceName = typeof(T).Name;
            if (typeof(T).IsGenericType) //如果是泛型的类型
            {
                interFanceName += "_" + typeof(T).GetGenericArguments()[0].Name;
            }
            var instance = CallContext.GetData(interFanceName) ;
            //判断线程里面是否有数据
            if (instance == null) //线程的数据槽里面没有次上下文
            {
                //config找教主要
                instance = Activator.CreateInstance(typeof(T)); //创建了一个EF上下文                  
                //存储指定对象
                CallContext.SetData(interFanceName, instance);
            }
            return (T)instance;

        }

        
    }


}

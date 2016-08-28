﻿
using System;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Core.Exception;
using Core.Log;

namespace Core.Service
{
    public class ServiceContext
    {

        /// 暂时使用引用服务方式，可以改造成注入，或使用WCF服务方式
        /// 
       
        public static ServiceFactory Current
        {
            get
            {
                return new CacheServiceFactory();
            }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }

        //public ServiceContext(ServiceFactory factory)
        //{
        //    Current = factory;
        //}

        public static T CreateService<T>() where T : class, new()
        {
            var service = Current.CreateService<T>();
            //
            //可以拦截，写日志
            //
            var gernerator = new ProxyGenerator();
            var dynamicProxy = gernerator.CreateInterfaceProxyWithTargetInterface<T>(service, new InvokeInterceptor());
            return dynamicProxy;
        }
    }

    public class InvokeInterceptor : IInterceptor
    {
        public InvokeInterceptor()
        {
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception exception)
            {

                if (exception is BaseException)
                    throw;

                var message = new
                {
                    exception = exception.Message,
                    exceptionContext = new
                    {
                        method = invocation.Method.ToString(),
                        arguments = invocation.Arguments,
                        returnValue = invocation.ReturnValue
                    }
                };

                Log4NetHelper.Error(LoggerType.ServiceExceptionLog, message, exception);
                throw;
            }
        }
    }
}
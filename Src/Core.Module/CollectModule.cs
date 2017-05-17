using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Module
{
    public class CollectModule : IHttpModule
    {
        private static readonly object _moduleStart = new object();
        private static bool _isStarted = false;
        private static Dictionary<string, ContextCollectHandler> handlers;
        public void Init(HttpApplication context)
        {
            if (!_isStarted)
                lock (_moduleStart)
                {
                    if (!_isStarted)
                    {
                        _isStarted = true;
                        this.InitHandlers();
                    }
                }
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, System.EventArgs e)
        {
            var context = HttpContext.Current;
            var path = context.Request.CurrentExecutionFilePath;

            if (!path.EndsWith("collect.axd", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            path = path.Substring(path.IndexOf("/", StringComparison.Ordinal) + 1);
            var handler = path.Substring(0, path.LastIndexOf(".", StringComparison.Ordinal)).ToLower();
            if (handlers.ContainsKey(handler))
            {
                handlers[handler].ProcessRequest(context);
            }

        }

        public void Dispose()
        {


        }

        private void InitHandlers()
        {
            if (handlers == null)
            {
                handlers=new Dictionary<string, ContextCollectHandler>();
            }

            var handlerTypes =
                this.GetType().Assembly.GetTypes().Where(r => r.BaseType == typeof (ContextCollectHandler));
            foreach (var handler in handlerTypes)
            {
                if(handlers.ContainsKey(handler.Name))continue;
                var instance = Activator.CreateInstance(handler) as ContextCollectHandler;
                if (instance != null)
                {
                    handlers.Add(handler.Name.ToLower(),instance);
                }
            }
        }
    }
}

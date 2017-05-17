using System.Linq;
using System.Reflection;
using System.Web;

namespace Framework.Job
{
    public class JobModule : IHttpModule
    {
        private static readonly object Mlock = new object();
        private bool _isInit = false;
        //private static JobBase _jobBase = null;
        public void Init(HttpApplication context)
        {
            if (_isInit) return;
            lock (Mlock)
            {
                if (_isInit) return;
                context.BeginRequest += Context_BeginRequest;
                JobEnsureInit();
                this._isInit = true;
            }
        }

        private void Context_BeginRequest(object sender, System.EventArgs e)
        {
            var context = HttpContext.Current;
            var path = context.Request.CurrentExecutionFilePath;
            if (!path.EndsWith(".job"))
            {
                return;
            }

        }

        private void JobEnsureInit()
        {
             
            //todo:反射把所有的数据都添加到Invoke里面
            var jobCollect = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(r => r.BaseType != null && r.BaseType == typeof(JobBase));
            foreach (var job in jobCollect)
            {
                
            }
            
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Log;

namespace Tools.NodeService
{
    public abstract class BaseMonitor
    {
        public abstract void Run();

        public abstract int Interval { get; set; }

        public BaseMonitor()
        {
            Init();
        }

        public virtual void Init()
        {
            Task.Factory.StartNew(TryRun);
        }
        public void TryRun()
        {

            while (true)
            {
                try
                {
                    Run();
                    Thread.Sleep(Interval);
                }
                catch (Exception exp)
                {

                    Log4NetHelper.Error(LoggerType.ServiceExceptionLog, this.GetType().Name + "出现严重错误", exp);
                }

            }

        }
    }
}
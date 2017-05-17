using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Framework.Job
{
    public abstract class JobBase
    {
        
      

        public JobBase(string jobName,Action<string>action)
        {
            MethodInvoker[jobName] = action;
        }
        public abstract void Run();

        private void TryRun()
        {
            try
            {
                Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
  

        public dynamic MethodInvoker { get; set; }
    }
}

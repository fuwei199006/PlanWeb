using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Tools.NodeService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new NoderService(), 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}

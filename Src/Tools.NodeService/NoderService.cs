using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Tools.NodeService
{
    public partial class NoderService : ServiceBase
    {
        public NoderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            File.WriteAllText("1.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var testMonitor = new TestMonitor();
        }

        protected override void OnStop()
        {
        }
    }
}

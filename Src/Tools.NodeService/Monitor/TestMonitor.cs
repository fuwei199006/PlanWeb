using System;
using System.IO;

namespace Tools.NodeService
{
    public class TestMonitor:BaseMonitor
    {

        public TestMonitor()
        {
            Interval = 5000;
        }
        public override void Run()
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory+"//1.txt",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\n");
        }

        public sealed override int Interval { get; set; }
    }
} 
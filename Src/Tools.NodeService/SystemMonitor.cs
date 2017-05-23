using System;
using System.Collections.Generic;
using System.Linq;
using Core.Log;
using Core.Message;
using Framework.Utility.Utility;

namespace Tools.NodeService
{
    public class SystemMonitor:BaseMonitor
    {
        public SystemMonitor()
        {
            Interval = 1000;
        }

        private readonly List<float> _cpusList=new List<float>();
        private readonly List<float> _memeryList=new List<float>();
        private bool _isCpuCheck;
        private bool _isMemmerCheck;
        public override void Run()
        {
            var cpu = SysMonitor.GetCurrentCpuUsage();
            if (cpu > 90) _isCpuCheck = true;//开始出现CPU大于90的时候开始监控
            if (_isCpuCheck)
            {
                _cpusList.Add(cpu);
            }
          

            var memery = SysMonitor.GetAvailableRam();
            if (memery < 10)
            {
                _isMemmerCheck = true;
            }
            if (_isMemmerCheck)
            {
                _memeryList.Add(memery);
            }
 
            if (_cpusList.Count > 60)
            {
    
                if (_cpusList.Average() > 90)
                {
                    //todo:sentmail
                    Log4NetHelper.Error(LoggerType.ServiceExceptionLog, "cpu资源紧张：连续1分钟CPU使用率超过90%", new Exception("cpu资源紧张：连续1分钟CPU使用率超过90%"));

                    MailContext.SendEmail("756091180@qq.com", "", "cpu资源紧张",
                        "cpu资源紧张：连续1分钟CPU使用率超过90%");

                }
                _cpusList.Clear();
                _isCpuCheck = false;
            }

            if (_memeryList.Count>60)
            {
                if (_memeryList.Average() > 10)//小于10MB
                {
                    //todo:sentmail
                    Log4NetHelper.Error(LoggerType.ServiceExceptionLog, "内存资源紧张：连续1分钟可使用内存小于10MB", new Exception("内存资源紧张：连续1分钟可使用内存小于10MB"));

                    MailContext.SendEmail("756091180@qq.com", "", "内存资源紧张",
                        "内存资源紧张：连续1分钟可使用内存小于10MB");
                }
                _memeryList.Clear();
                _isMemmerCheck = false;
            }
        }

        public sealed override int Interval { get; set; }
    }
}
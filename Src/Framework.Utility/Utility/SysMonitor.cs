using System;
using System.Diagnostics;

namespace Framework.Utility.Utility
{
    public class SysMonitor:IDisposable
    {
        static   PerformanceCounter _cpuCounter;
        static   PerformanceCounter _ramCounter;

        static SysMonitor()
        {
            _cpuCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
 
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
      

        public static float GetCurrentCpuUsage()
        {
            return _cpuCounter.NextValue();
        }

        public static float GetAvailableRam()
        {
            return _ramCounter.NextValue();
        }

        public void Dispose()
        {
            _cpuCounter = null;
            _ramCounter = null;
        }
    }
}
﻿using System;

namespace Core.Config.ConfigModel
{
    public class SystemConfig
    {
        public bool IsMonitor { get; set; }//数据日志

        public int CookieExpiteTime { get; set; }

        public int CacheExpiteTime { get; set; }

        public Guid SystemId { get; set; }

        public bool IsRunning { get; set; }
    }


   
}
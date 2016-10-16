using System;

namespace Core.Config.ConfigModel
{
    [Serializable]
    public class SystemSettingConfig
    {
        public bool IsMonitor { get; set; }//数据日志

        public int CookieExpiteTime { get; set; }

        public int CacheExpiteTime { get; set; }

        public Guid SystemId { get; set; }

        public bool IsRunning { get; set; }
        public string WebSiteTitle { get; set; }
        public string WebSiteDescription { get; set; }
        public string WebSiteKeyWords { get; set; }
    }



}
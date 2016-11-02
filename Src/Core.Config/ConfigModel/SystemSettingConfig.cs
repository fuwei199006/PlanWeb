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

        //js和css用文件分离
        public string CurrentJsAndCssDoain { get; set; }

        //文件分离
        //todo:读写在一台服务器上面，后面再修改
        public string CurrentFileDomain { get; set; }
    }



}
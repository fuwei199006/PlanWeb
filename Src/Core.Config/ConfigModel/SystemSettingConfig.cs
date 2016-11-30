using System;

namespace Core.Config.ConfigModel
{
    [Serializable]
    public class SystemSettingConfig : ConfigBase
    {
        public bool IsDbMonitor { get; set; }//数据日志

        public int CookieExpireTime { get; set; }

        public int CacheExpiteTime { get; set; }

        public Guid SystemId { get; set; }

        public bool  Runable { get; set; }//能否启动系统，一键关闭

        public string WebSiteTitle { get; set; }//系统标题

        public string WebSiteDescription { get; set; }//系统描述，关于系统

        public string WebSiteKeyWords { get; set; }//SEO关键字

        //js和css用文件分离
        public string CdnDomain { get; set; }

        //文件分离
        //todo:读写在一台服务器上面，后面再修改
        public string FileDomain { get; set; }
    }



}
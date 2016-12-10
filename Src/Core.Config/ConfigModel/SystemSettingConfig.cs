using System;

namespace Core.Config.ConfigModel
{
    [Serializable]
    public class SystemSettingConfig : ConfigBase
    {
        public bool IsDbMonitor { get; set; }//数据日志

        public int CookieExpireTime { get; set; }//min

        public int CacheExpiteTime { get; set; }//min

        public Guid SystemId { get; set; }//用户加密系统内的数据

        public bool  Runable { get; set; }//能否启动系统，一键关闭

        public string WebSiteTitle { get; set; }//系统标题

        public string WebSiteDescription { get; set; }//系统描述，关于系统

        public string WebSiteKeyWords { get; set; }//SEO关键字

        //js和css用文件分离
        public string CdnDomain { get; set; }

        //文件分离
        //todo:读写在一台服务器上面，后面再修改
        public string FileDomain { get; set; }

        public string SysAdmin { get; set; }// 系统超级管理员,不做权限的认证
    }



}
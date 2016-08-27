using System;

namespace Core.Config.ConfigModel
{

    /// <summary>
    /// 网站的配置
    /// </summary>
      [Serializable]
    public class SettingConfig
    {
        #region 网站的配置
        public string WebSiteTitle { get; set; }
        public string WebSiteDescription { get; set; }
        public string WebSiteKeyWords { get; set; } 
        #endregion
    }
}
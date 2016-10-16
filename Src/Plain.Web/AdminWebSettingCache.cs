using System.Collections.Generic;
using Core.Cache;
using Core.Config.ConfigModel;
using Core.Service;
using Plain.BLL.MenuService;
using Plain.Dto;

namespace Plain.Web
{
    public class AdminWebSettingCache
    {
   
        public static AdminWebSettingCache Current
        {
            get
            {
                return CacheContext.GetItem<AdminWebSettingCache>();
            }
        }
        public virtual SystemSettingConfig SystemSettingConfig
        {
            get
            {
                return CacheContext.Get(CacheKey.SystemTitle, () => new SystemSettingConfig()
                {
                    WebSiteTitle = "Plain系统"
                });
            }
        }
    }
}
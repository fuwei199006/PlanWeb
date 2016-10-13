using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utility
{
    public sealed class CacheKey
    {

        #region 本地缓存的key

        public const string CacheConfig = "Cache-CacheConfig";
        public const string DaoConfig = "Dao-DaoConfig";
        public const string SettingConfig = "Web-SettingConfig";
        public const string Mail163Config = "Message-Mail163Config";
        public const string SystemConfig = "Sys-SystemConfig"; 

        #endregion

    }
}

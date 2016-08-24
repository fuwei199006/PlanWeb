using System.Net.Configuration;
using Core.Config.ConfigModel;
using Framework.Utility;

namespace Core.Config
{
    public class LocalCachedConfigContext : ConfigContext
    {
        public override T Get<T>(string keyOrName)
        {
            var result = (T)Caching.Get(keyOrName);
            if (result == null)
            {
                result = base.Get<T>(keyOrName);
                Caching.Set(keyOrName, result);
            }
            return result;
        }

        public static LocalCachedConfigContext Current
        {
            get { return new LocalCachedConfigContext(); }
        }

        public CacheConfig CacheConfig
        {
            get
            {
                return this.Get<CacheConfig>("CacheConfig"); 
                
            }
        }

        public DaoConfig DaoConfig
        {
            get
            {
                return this.Get<DaoConfig>("DaoConfig");
                
            }
        }
    }
}
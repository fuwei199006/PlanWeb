using Core.Config;
using Core.Exception;
using Framework.Utility.Extention;
using System;
using System.Linq;

namespace Core.Cache
{
    public class RadisProvider : ICacheProvider
    {

        public RadisProvider()
        {
            var cacheProviderItem = LocalCachedConfigContext.Current.CacheConfig.CacheProviderItems.FirstOrDefault(r => r.Type.TrimAll() == (this.GetType().FullName.ToString() + "," + this.GetType().Namespace));
            if (cacheProviderItem == null)
            {
                throw new ConfigInvalidException("配置错误:可能是使用的分布式缓存,但配置文件没有正确的配置成分布式的Provider");
            }

            RadisUtil.IP = cacheProviderItem.Ips;
            RadisUtil.Port = cacheProviderItem.Port;

        }
        public object Get(string key)
        {
            return RadisUtil.Get(key);
        }

        public void Set(string key, object value)
        {
            RadisUtil.Set(key, value);
        }

        public void Remove(string key)
        {
            RadisUtil.Remove(key);
        }

        public void Set(string key, object value, int min)
        {
            RadisUtil.Set(key, value, min);
        }
    }
}
using System;
using System.Linq;
using Core.Config;
using Core.Config.ConfigModel;
using Core.Exception;
using Memcached.ClientLibrary;

namespace Core.Cache
{
    public class MemcacheProvider : ICacheProvider
    {

        public MemcacheProvider()
        {
            var cacheProviderItem = LocalCachedConfigContext.Current.CacheConfig.CacheProviderItems.FirstOrDefault(r => r.Type == (this.GetType().FullName.ToString()+","+ this.GetType().Namespace));
            if (cacheProviderItem == null)
            {
                throw new ConfigInvalidException("配置错误:可能是使用的分布式缓存,但配置文件没有正确的配置成分布式的Provider");
            }
                MemcacheUtil.MemcacheServiceList =
                    cacheProviderItem.Ips;
        }

        public object Get(string key)
        {
            return MemcacheUtil.Get(key);
        }

        public void Set(string key, object value)
        {
            MemcacheUtil.Set(key, value);
        }

        public void Remove(string key)
        {
            MemcacheUtil.Remove(key);
        }



        public void Set(string key, object value, int min)
        {
            MemcacheUtil.Set(key, value, min);
        }


    }
}
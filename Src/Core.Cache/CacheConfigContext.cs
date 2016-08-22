using System;
using System.Collections.Generic;
using System.Linq;
using Core.Config;
using Core.Config.ConfigModel;

namespace Core.Cache
{
    public class CacheConfigContext
    {
         private static readonly object _olock=new  object();

        internal static CacheConfig CacheConfig
        {
            get { return LocalCachedConfigContext.Current.CacheConfig; }
        }


        public class WrapCacheConfigItem
        {
            public CacheConfigItem CacheConfigItem { get; set; }
            public CacheProviderItem CacheProviderItem { get; set; }
            public ICacheProvider CacheProvider { get; set; }
        }
        private static List<WrapCacheConfigItem> _wrapCacheConfigItems;
        internal static List<WrapCacheConfigItem> WrapCacheConfigItems
        {
            get
            {
                if (_wrapCacheConfigItems == null)
                {
                    _wrapCacheConfigItems = new List<WrapCacheConfigItem>();

                    foreach (var i in CacheConfig.CacheConfigItems)
                    {
                        var cacheWrapConfigItem = new WrapCacheConfigItem()
                        {
                            CacheConfigItem = i,
                            CacheProviderItem = CacheConfig.CacheProviderItems.SingleOrDefault(c => c.Name == i.ProviderName),
                            CacheProvider = CacheProviders[i.ProviderName]
                        };
                        _wrapCacheConfigItems.Add(cacheWrapConfigItem);
                    }
                }

                return _wrapCacheConfigItems;
            }
        }

        /// <summary>
        /// 首次加载所有的CacheProviders
        /// </summary>
        private static Dictionary<string, ICacheProvider> _cacheProviders;
        internal static Dictionary<string, ICacheProvider> CacheProviders
        {
            get
            {
                if (_cacheProviders == null)
                {
                    lock (_olock)
                    {
                        if (_cacheProviders == null)
                        {
                            _cacheProviders = new Dictionary<string, ICacheProvider>();

                            foreach (var i in CacheConfig.CacheProviderItems)
                                // ReSharper disable once AssignNullToNotNullAttribute
                                _cacheProviders.Add(i.Name, (ICacheProvider)Activator.CreateInstance(type: Type.GetType(i.Type)));
                        }
                    }
                }

                return _cacheProviders;
            }
        }

    }
}
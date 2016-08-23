using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Core.Config;
using Core.Config.ConfigModel;
using Core.Exception;

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
        private static Dictionary<string, WrapCacheConfigItem> _wrapCacheConfigItemDic;
        internal static  WrapCacheConfigItem  GetCurrentWrapCacheConfigItem(string key)
        {
            if (_wrapCacheConfigItemDic == null)
            {
                _wrapCacheConfigItemDic=new Dictionary<string, WrapCacheConfigItem>();
            }
            if (_wrapCacheConfigItemDic.ContainsKey(key))
            {
                return _wrapCacheConfigItemDic[key];
            }

            //这个是数据 和匹配的 作用还没有清析
            //2016.08.23
            var currentWrapCacheConfigItem = WrapCacheConfigItems.Where(r =>
                Regex.IsMatch(ModuleName, r.CacheConfigItem.ModuleRegex, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(key, r.CacheConfigItem.KeyRegex, RegexOptions.IgnoreCase))
                .OrderByDescending(i => i.CacheConfigItem.Priority)
                .FirstOrDefault();
            if (currentWrapCacheConfigItem == null)
            {
                throw new GetCacheException("获得缓存数据出错！请确保配置正确");
            }

            lock (_olock)
            {
                if (!_wrapCacheConfigItemDic.ContainsKey(key))
                    _wrapCacheConfigItemDic.Add(key, currentWrapCacheConfigItem);
            }

            return currentWrapCacheConfigItem;
        }


     

        /// <summary>
        /// 得到网站项目的入口程序模块名名字，用于CacheConfigItem.ModuleRegex
        /// </summary>
        /// <returns></returns>
        private static string moduleName;
        public static string ModuleName
        {
            get
            {
                if (moduleName == null)
                {
                    lock (_olock)
                    {
                        if (moduleName == null)
                        {
                            var entryAssembly = Assembly.GetEntryAssembly();

                            if (entryAssembly != null)
                            {
                                moduleName = entryAssembly.FullName;
                            }
                            else
                            {
                                moduleName = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Name;
                            }
                        }
                    }
                }

                return moduleName;
            }
        }

    }
}
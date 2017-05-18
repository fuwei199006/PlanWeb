/*
* @Author: 付威
* @Date:   2016-08-23 23:03:45
* @Last Modified by:   付威
* @Last Modified time: 2016-08-23 23:24:59
*/
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
        private static readonly object Olock = new object();

        private static CacheConfig CacheConfig => LocalCachedConfigContext.Current.CacheConfig;


        private static List<WrapCacheConfigItem> _wrapCacheConfigItems;

        private static List<WrapCacheConfigItem> WrapCacheConfigItems
        {
            get
            {
                if (_wrapCacheConfigItems == null || !_wrapCacheConfigItems.Any())
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
        /// todo: 可能导致当前的_cacheProvider没有释放。
        /// </summary>
        private static Dictionary<string, ICacheProvider> _cacheProviders;
        internal static Dictionary<string, ICacheProvider> CacheProviders
        {
            get
            {
                //如果数据有变动的
                //1.数据为空，2.长度不相等，3.要有对应的key和value相同
                if (IsNeedRefreshMember())
                {
                    lock (Olock)
                    {
                        if (IsNeedRefreshMember())
                        {
                            _cacheProviders = new Dictionary<string, ICacheProvider>();

                            foreach (var i in CacheConfig.CacheProviderItems)
                                _cacheProviders.Add(i.Name, (ICacheProvider)Activator.CreateInstance(Type.GetType(i.Type)));
                        }
                    }
                }

                return _cacheProviders;
            }
        }
        private static Dictionary<string, WrapCacheConfigItem> _wrapCacheConfigItemDic;
        internal static WrapCacheConfigItem GetCurrentWrapCacheConfigItem(string key)
        {
            if (_wrapCacheConfigItemDic == null)
            {
                _wrapCacheConfigItemDic = new Dictionary<string, WrapCacheConfigItem>();
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

            //var currentWrapCacheConfigItems = WrapCacheConfigItems.Where(r =>
            //    Regex.IsMatch(ModuleName, r.CacheConfigItem.ModuleRegex, RegexOptions.IgnoreCase) &&
            //    Regex.IsMatch(key, r.CacheConfigItem.KeyRegex, RegexOptions.IgnoreCase))
            //    .OrderByDescending(i => i.CacheConfigItem.Priority);

            if (currentWrapCacheConfigItem == null)
            {
                throw new GetCacheException("获得缓存数据出错！请确保配置正确");
            }
            lock (Olock)
            {
                if (!_wrapCacheConfigItemDic.ContainsKey(key))
                {
                    _wrapCacheConfigItemDic.Add(key, currentWrapCacheConfigItem);
                }
            }

            return currentWrapCacheConfigItem;
        }




        /// <summary>
        /// 得到网站项目的入口程序模块名名字，用于CacheConfigItem.ModuleRegex
        /// </summary>
        /// <returns></returns>
        private static string _moduleName;
        public static string ModuleName
        {
            get
            {
                if (_moduleName == null)
                {
                    lock (Olock)
                    {
                        if (_moduleName == null)
                        {
                            var entryAssembly = Assembly.GetEntryAssembly();

                            if (entryAssembly != null)
                            {
                                _moduleName = entryAssembly.FullName;
                            }
                            else
                            {
                                _moduleName = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Name;
                            }
                        }
                    }
                }

                return _moduleName;
            }
        }

        private static bool IsNeedRefreshMember()
        {
            if (_cacheProviders?.Count != CacheConfig.CacheProviderItems.Length) return true;
            var itemsArr = CacheConfig.CacheConfigItems.Select(x => x.ProviderName);
            if (_cacheProviders.Keys.Any(r => !itemsArr.Contains(r))) return true;
            var providerArr = CacheConfig.CacheProviderItems.Select(x => x.Type);
            if (_cacheProviders.Values.Any(r => !providerArr.Contains(r.GetType().FullName + "," + r.GetType().Namespace)))
                return true;
            return false;
        }

    }


    public class WrapCacheConfigItem
    {
        public CacheConfigItem CacheConfigItem { get; set; }
        public CacheProviderItem CacheProviderItem { get; set; }
        public ICacheProvider CacheProvider { get; set; }
    }
}
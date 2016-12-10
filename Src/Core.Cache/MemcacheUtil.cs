using System;
using System.Configuration;
using Core.Exception;
using Memcached.ClientLibrary;

namespace Core.Cache
{
    public class MemcacheUtil
    {

        private const string SockIoPoolName = "PlainMemPool";
        private static void  MemcacheInit()
        {
            if (string.IsNullOrEmpty(MemcacheServiceList))
            {
                throw new ArgumentException("Memcache的服务器不正确。");
            }
            var sPool = SockIOPool.GetInstance(SockIoPoolName);
            sPool.SetServers(MemcacheServiceList.Split(','));
            sPool.Initialize();
        }

       public static string MemcacheServiceList { get; set; }
        private static MemcachedClient _memcachedClient;

        public static MemcachedClient MemcachedClient
        {
            get
            {
                if (_memcachedClient == null)
                {
                    MemcacheInit();
                    _memcachedClient = new MemcachedClient { PoolName = SockIoPoolName };
                      
                }
                return _memcachedClient;
            }

        }

        public static object Get(string key)
        {
            return MemcachedClient.Get(key);
        }



        public static void Remove(string key)
        {
            MemcachedClient.Delete(key);
        }



        public static void Set(string key, object value, int min)
        {
            MemcachedClient.Set(key, value, DateTime.Now.AddMinutes(min));
        }
        public static void Set(string key, object value)
        {
            Set(key, value, 20);
        }
 


    }
}
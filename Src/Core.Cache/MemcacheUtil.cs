using System;
using Memcached.ClientLibrary;

namespace Core.Cache
{
    public class MemcacheUtil
    {

        private const string SockIoPoolName = "PlainMemPool";
        static MemcacheUtil()
        {
            //参数设置
            //todo:改成配置
            string[] memcacheServiceList = { "127.0.0.1:11211" };

            //设置连接池
            var sPool = SockIOPool.GetInstance(SockIoPoolName);
            sPool.SetServers(memcacheServiceList);
            sPool.Initialize();
        }

        private static MemcachedClient _memcachedClient;

        public static MemcachedClient MemcachedClient
        {
            get
            {
                if (_memcachedClient == null)
                {
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
        public static void Set(string key, object value, int minutes, Action<string, object, string> onRemove)
        {

        }


    }
}
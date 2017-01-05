using Core.Config;
using ServiceStack.Redis;
using System;

namespace Core.Cache
{
    public class RadisUtil
    {

        public static string IP { get; set; }
        public static int Port { get; set; }
        private static RedisClient _redisClient;
       public static RedisClient RedisClient
        {
            get
            {
                if (_redisClient == null)
                {
                    _redisClient= new RedisClient(IP, Port);
                }
                return _redisClient;
            }
        }


        public static object Get(string key)
        {
            return RedisClient.Get(key);
        }



        public static void Remove(string key)
        {
            RedisClient.Delete(key);
        }



        public static void Set(string key, object value, int min)
        {
            RedisClient.Set(key, value, DateTime.Now.AddMinutes(min));
        }
        public static void Set(string key, object value)
        {
            Set(key, value, LocalCachedConfigContext.Current.SystemConfig.CacheExpiteTime);
        }


    }
}
using System;
using Memcached.ClientLibrary;

namespace Core.Cache
{
    public class MemcacheProvider : ICacheProvider
    {

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
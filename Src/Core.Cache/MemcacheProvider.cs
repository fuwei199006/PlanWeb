using System;

namespace Core.Cache
{
    public class MemcacheProvider : ICacheProvider
     
    {
        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
        
        }

        public void Clear(string regKey)
        {
         
        }

        public void Set(string key, object value, int min)
        {
       
        }

        public void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove)
        {
        
        }
    }
}
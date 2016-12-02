using System;

namespace Core.Cache
{
    public class RadiusProvider : ICacheProvider
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
            throw new NotImplementedException();
        }

        public void Clear(string regKey)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, int min)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove)
        {
            throw new NotImplementedException();
        }
    }
}
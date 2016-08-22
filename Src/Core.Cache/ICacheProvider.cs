using System;
using System.Dynamic;

namespace Core.Cache
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object value);
        void Remove(string key);
        void Clear(string regKey);
        void Set(string key, object value, int min);
        void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove);

    }
}

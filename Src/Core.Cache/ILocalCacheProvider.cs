using System;

namespace Core.Cache
{
    public interface ILocalCacheProvider
    {
        void Clear(string regKey);
        void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove);
    }
}
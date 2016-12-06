using System;

namespace Core.Cache
{
    public interface IAdvanceCacheProvider
    {
        void Clear(string regKey);
        void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove);
    }
}
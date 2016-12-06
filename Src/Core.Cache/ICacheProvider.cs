using System;
using System.Dynamic;

namespace Core.Cache
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object value);
        void Remove(string key);

        void Set(string key, object value, int min);


    }
}

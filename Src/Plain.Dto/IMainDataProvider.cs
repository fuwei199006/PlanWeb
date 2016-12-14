using System.Collections.Generic;

namespace Plain.Dto
{
    public interface IMainDataProvider
    {
       
        Dictionary<string, string> GetStrValueDescDictionary<T>();
        Dictionary<int, string> GetIntValueDescDictionary<T>();
        Dictionary<int, T> GetIntValueEntityDictionary<T>();
        Dictionary<string, T> GetStrValueEntityDictionary<T>();
        Dictionary<TKey, T> GetDictionary<TKey, T>();

    }
}
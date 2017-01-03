using System.Collections.Generic;

namespace Framework.Utility.Extention.MainData
{
    public interface IMainDataProvider
    {

        Dictionary<string, string> GetStrValueDescDictionary<T>();
        Dictionary<int, string> GetIntValueDescDictionary<T>();
        Dictionary<int, T> GetIntValueEntityDictionary<T>();
        Dictionary<string, T> GetStrValueEntityDictionary<T>();
        T  GetEntityByValue<T>(int value);
         T  GetEntityByFiled<T>(string filed);

    }
}
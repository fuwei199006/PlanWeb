using System.Collections.Generic;

namespace Framework.Utility.Extention.MainData
{
    public interface IMainDataProvider
    {
        Dictionary<string, string> GetStrValueDescDictionary<T>();
        Dictionary<int, string> GetIntValueDescDictionary<T>() ;
        Dictionary<int, EnumTitleAttribute> GetIntValueEntityDictionary<T>();
        Dictionary<string, EnumTitleAttribute> GetStrValueEntityDictionary<T>();
        EnumTitleAttribute GetEntityByValue<T>(int value);
        EnumTitleAttribute GetEntityByFiled<T>(string filed);
        string GetDescByFiled<T>(string filed);
        string GetDescByValue<T>(int value);

    }
}
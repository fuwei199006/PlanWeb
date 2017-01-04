using System;
using System.Collections.Generic;

namespace Framework.Utility.Extention.MainData
{
    /// <summary>
    /// 手动实现
    /// </summary>
    public class FileProvider : IMainDataProvider
    {
        public string GetDescByFiled<T>(string filed)
        {
            throw new NotImplementedException();
        }

        public string GetDescByValue<T>(int value)
        {
            throw new NotImplementedException();
        }

        public EnumTitleAttribute GetEntityByFiled<T>(string filed)
        {
            throw new NotImplementedException();
        }

        public EnumTitleAttribute GetEntityByValue<T>(int value)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetIntValueDescDictionary<T>()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, EnumTitleAttribute> GetIntValueEntityDictionary<T>()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetStrValueDescDictionary<T>()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, EnumTitleAttribute> GetStrValueEntityDictionary<T>()
        {
            throw new NotImplementedException();
        }
    }
}
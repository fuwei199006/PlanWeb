using System.Collections.Generic;
using Framework.Extention;

namespace Plain.Dto
{
    public class EnumProvider:IMainDataProvider
    {
        public Dictionary<string, string> GetStrValueDescDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<int, string> GetIntValueDescDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<int, T> GetIntValueEntityDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, T> GetStrValueEntityDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<TKey, T> GetDictionary<TKey, T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
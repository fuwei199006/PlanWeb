using System.Collections.Generic;

namespace Plain.Dto.MainData
{
    public class DbProvider : IMainDataProvider
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Utility.Extention.MainData
{
    public class EnumProvider : IMainDataProvider
    {

        private const string ENUM_TITLE_SEPARATOR = ",";
        public Dictionary<string, string> GetStrValueDescDictionary<T>()
        {
            var dicEntityDesc = GetItemAttributeList<T>();
            return dicEntityDesc.ToDictionary(x => x.Key.ToString(), u => u.Value.Title);
 
        }

        public Dictionary<int, string> GetIntValueDescDictionary<T>()
        {
            var dicEntityDesc = GetItemAttributeList<T>();
            return dicEntityDesc.ToDictionary(x => Convert.ToInt32(x.Key), u => u.Value.Title);
        }


        public Dictionary<int, EnumTitleAttribute> GetIntValueEntityDictionary<T>()
        {
            var dicEntityDesc = GetItemAttributeList<T>();
            return dicEntityDesc.ToDictionary(x => Convert.ToInt32(x.Key), u => u.Value);
        }

        public Dictionary<string, EnumTitleAttribute> GetStrValueEntityDictionary<T>()
        {
            var dicEntityDesc = GetItemAttributeList<T>();
            return dicEntityDesc.ToDictionary(x => x.Key.ToString(), u => u.Value);
        }

        public Dictionary<T, EnumTitleAttribute> GetDictionary<T>()
        {
            var dicEntityDesc = GetItemAttributeList<T>();
            return dicEntityDesc;
        }

        public EnumTitleAttribute GetEntityByValue<T>(int value)
        {
            var dicEntityDesc = GetIntValueEntityDictionary<T>();
            return dicEntityDesc[value];
        }
        public string GetDescByValue<T>(int value)
        {
            var dicEntityDesc = GetIntValueEntityDictionary<T>();
            if (dicEntityDesc.ContainsKey(value))
            {
                return dicEntityDesc[value].Title;
            }
            return string.Empty;
        }

        public string GetDescByFiled<T>(string filed)
        {
            var dicEntityDesc = GetStrValueEntityDictionary<T>();
            if (dicEntityDesc.ContainsKey(filed))
            {
                return dicEntityDesc[filed].Title;
            }
            return string.Empty;
        }

        public EnumTitleAttribute GetEntityByFiled<T>(string filed)
        {
            var dicEntityDesc = GetStrValueEntityDictionary<T>();
            return dicEntityDesc[filed];

        }


        private Dictionary<T, EnumTitleAttribute> GetItemAttributeList<T>(Enum language = null)
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("参数必须是枚举！");
            }
            Dictionary<T, EnumTitleAttribute> ret = new Dictionary<T, EnumTitleAttribute>();

            Array array = typeof(T).GetEnumValues();
            foreach (object t in array)
            {
                EnumTitleAttribute att = GetEnumTitleAttribute(t as Enum, language);
                if (att != null)
                    ret.Add((T)t, att);
            }

            return ret;
        }

        private EnumTitleAttribute GetEnumTitleAttribute(Enum e, Enum language = null)
        {
            if (e == null)
            {
                return null;
            }
            string[] valueArray = e.ToString().Split(ENUM_TITLE_SEPARATOR.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Type type = e.GetType();
            EnumTitleAttribute ret = null;
            foreach (string enumValue in valueArray)
            {
                System.Reflection.FieldInfo fi = type.GetField(enumValue.Trim());
                if (fi == null)
                    continue;
                EnumTitleAttribute[] attrs = fi.GetCustomAttributes(typeof(EnumTitleAttribute), false) as EnumTitleAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    ret = attrs[0];
                    break;
                }
            }
            return ret;
        }


    }
}
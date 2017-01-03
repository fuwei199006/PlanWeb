using System;
using System.Collections.Generic;

namespace Framework.Utility.Extention.MainData
{
    public class EnumProvider:IMainDataProvider
    {

        private  const   string ENUM_TITLE_SEPARATOR = ",";
        public Dictionary<string, string> GetStrValueDescDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<int, string> GetIntValueDescDictionary<T>()  
        {
            var dic = GetItemAttributeList<T>();

            Dictionary<int, string> dicNew = new Dictionary<int, string>();
            //foreach (var d in dic)
            //{
            //    if (exceptTypes != null && exceptTypes.Contains(d.Key))
            //    {
            //        continue;
            //    }
            //    dicNew.Add(d.Key.GetHashCode(), d.Value);
            //}
            return dicNew;
        }
      

        public Dictionary<int, T> GetIntValueEntityDictionary<T>()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, T> GetStrValueEntityDictionary<T>()
        {
            Dictionary<string, T> ret = new Dictionary<string, T>();
            //枚举值
            Array arrEnumValue = typeof(T).GetEnumValues();
            foreach (object enumValue in arrEnumValue)
            {
                System.Reflection.FieldInfo fi = typeof(T).GetField(enumValue.ToString());
                if (fi == null)
                {
                    continue;
                }

                EnumTitleAttribute[] arrEnumTitleAttr = fi.GetCustomAttributes(typeof(EnumTitleAttribute), false) as EnumTitleAttribute[];
                if (arrEnumTitleAttr == null || arrEnumTitleAttr.Length < 1 || !arrEnumTitleAttr[0].IsDisplay)
                {
                    continue;
                }

                if (!ret.ContainsKey(arrEnumTitleAttr[0].Title))
                {
                    ret.Add(arrEnumTitleAttr[0].Title, (T)enumValue);
                }

                if (arrEnumTitleAttr[0].Synonyms == null || arrEnumTitleAttr[0].Synonyms.Length < 1)
                {
                    continue;
                }

                foreach (string s in arrEnumTitleAttr[0].Synonyms)
                {
                    if (!ret.ContainsKey(s))
                    {
                        ret.Add(s, (T)enumValue);
                    }
                }
            }//using
            return ret;
        }

        public Dictionary<TKey, T> GetDictionary<TKey, T>()
        {
            throw new System.NotImplementedException();
        }

        public T GetEntityByValue<T>(int value)
        {
            throw new NotImplementedException();
        }

        public T GetEntityByFiled<T>(string filed)
        {
            throw new NotImplementedException();
        }


        private   Dictionary<T, EnumTitleAttribute> GetItemAttributeList<T>(Enum language = null)  
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

        private  EnumTitleAttribute GetEnumTitleAttribute(Enum e, Enum language = null)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;


namespace Framework.Extention
{
    public static class EnmuExtention
    {
        public static T TryParse<T>(this string obj) where T : struct
        {
            return EnumHelper.TryParse<T>(obj);
        }

        public static string GetEnumTitle<T>(this T t) where T : struct
        {
            return EnumHelper.GetEnumTitle(t as Enum);
        }

        //public static Dictionary<TKey, EnumTitleAttribute> GetEnumTitleAttributes<TKey>() where TKey : struct
        //{
        //    return EnumHelper.GetItemAttributeList<TKey>();
        //}

        //public static Dictionary<string, EnumTitleAttribute> GetEnumFiledAttributes<TKey>() where TKey : struct
        //{
        //    return EnumHelper.GetEnumDictionary()<TKey>();
        //}
    }
}

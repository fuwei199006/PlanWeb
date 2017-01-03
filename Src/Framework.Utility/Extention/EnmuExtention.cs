using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace Framework.Utility.Extention
{
    public static class EnmuExtention
    {
        public static readonly string ENUM_TITLE_SEPARATOR = ",";
        public static T EnumTryParse<T>(this string obj) where T : struct
        {
            return EnumHelper.TryParse<T>(obj);
        }
        public static string GetEnumTitle<T>(this T t) where T : struct
        {
            return EnumHelper.GetEnumTitle(t as Enum);
        }



    }
}

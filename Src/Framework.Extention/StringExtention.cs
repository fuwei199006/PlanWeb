using Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extention
{
   public static class StringExtention
    {
        public static string CutString(this string str,int len)
        {
            return StringUtil.CutString(str, len);
        }

        public static string CutString(this string str)
        {
            return StringUtil.CutString(str, 20);
        }
 
    }
}

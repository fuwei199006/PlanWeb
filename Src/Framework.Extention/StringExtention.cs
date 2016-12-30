using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Framework.Extention
{
    public static class StringExtention
    {
        public static string CutString(this string str, int len)
        {
            return StringUtil.CutString(str, len);
        }

        public static string CutString(this string str)
        {
            return StringUtil.CutString(str, 20);
        }

        /// <summary>
        /// 字符包含字符集合
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strCollect">1;2;3;4</param>
        /// <param name="split">分割符</param>
        /// <returns></returns>
        public static bool ContainsCollectElement(this string str, string strCollect, char split)
        {
            var arr = strCollect.Split(split);
            return str.ContainsCollectElement(arr);
        }
        /// <summary>
        /// 字符包含数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strCollect">1;2;3;4</param>
        /// <param name="split">分割符</param>
        /// <returns></returns>
        public static bool ContainsCollectElement(this string str, string[] strCollect)
        {
            foreach (var item in strCollect)
            {
                if (str.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 字符包含字符集合
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strCollect">1;2;3;4</param>
        /// <param name="split">分割符</param>
        /// <returns></returns>
        public static bool ContainsCollectElement(this string str, string strCollect)
        {
            return str.ContainsCollectElement(strCollect, ';');
        }

        public static string GetSubtitle(this string str)
        {
            //Regex.Replace(str, @"<[^<>]+>|\s");
            return str.CutString(40);
        }
    }
}

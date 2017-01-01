using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

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
            var arr = strCollect.Split(split).Where(r=>!string.IsNullOrEmpty(r)).ToArray();
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
            return strCollect.Any(str.Contains);
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
             
            return str.RemoveHtml().CutString(60);
        }

        public static string RemoveHtml(this string str)
        {
            //删除脚本
            var htmlstring = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            htmlstring = htmlstring.Replace("<", "").Replace(">", "").Replace("\n", "").Replace("\r","");
            return htmlstring;
        }
    }
}

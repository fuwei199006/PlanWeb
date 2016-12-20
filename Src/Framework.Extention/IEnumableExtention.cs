using Framework.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extention
{
    public static class IEnumableExtention
    {

        /// <summary>
        /// 把数据转成标签
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string ToBadge(this IEnumerable<string> strs, string className)
        {
            if (strs.Count() == 0)
            {
                return string.Empty;
            }
            var badgeStr = new StringBuilder();
            foreach (var s in strs)
            {
                badgeStr.AppendFormat(@"<span class='{0}' style='margin-right: 2px;'>{1}</span>", className, s);
            }
            return badgeStr.ToString();

        }

        public static string ToBadge(this IEnumerable<string> strs)
        {

            return strs.ToBadge("label label-info");
        }

        public static string ToBadge(this string strs, string split, string className)
        {
            if (string.IsNullOrEmpty(strs))
            {
                return string.Empty;
            }
            var strArr = strs.Split(split.ToArray()).AsEnumerable();
            return strArr.ToBadge(className);

        }

        public static string ToBadge(this string strs, string className)
        {
            return strs.ToBadge(",", className);
        }
        public static string ToBadge(this string strs)
        {
            return strs.ToBadge(",", "label label-info");
        }
        /// <summary>
        /// 重写join的方法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split"></param>
        /// <param name="isKeep">是否保留最后一个逗号</param>
        /// <returns></returns>
        public static string ToJoin(this IEnumerable<string> strs, string split)
        {
            if (strs.Count() == 0)
            {
                return string.Empty;
            }
            return string.Join(split, strs);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split"></param>
        /// <param name="isKeep">是否保留最后一个逗号</param>
        /// <returns></returns>
        public static string ToJoin(this IEnumerable<string> strs)
        {
            return strs.ToJoin(",");
        }
    }
}

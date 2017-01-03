using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Framework.Utility
{
    /// <summary>
    /// Fetch 的摘要说明。
    /// </summary>
    public class Fetch
    {

        public static string Get(string name)
        {
            var text = HttpContext.Current.Request.QueryString[name];
            return string.IsNullOrEmpty(text) ? "" : text.Trim();

        }

        public static string Post(string name)
        {
            var text = HttpContext.Current.Request.Form[name];
            return string.IsNullOrEmpty(text) ? "" : text.Trim();

        }

        public static int GetQueryId(string name)
        {
            int id;
            int.TryParse(Get(name), out id);
            return id;

        }

        public static int[] GetIds(string name)
        {
            var ids = Post(name);
            var id = 0;
            var array = ids.Split(',');
            return (from s in array where int.TryParse(s.Trim(), out id) select id).ToArray();
        }

        /// <summary>
		/// 获取Url过来的值，如.....aspx?productid=2&productid=3，将是int[]{2,3}
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static int[] GetQueryIds(string name)
        {
            var ids = Get(name);
            int id = 0;
            var array = ids.Split(',');

            return (from a in array where int.TryParse(a.Trim(), out id) select id).ToArray();
        }

        public static string CurrentUrl
        {
            get { return HttpContext.Current.Request.Url.ToString(); }
        }

        public static string ServerDomain
        {
            get
            {
                var urlHost = HttpContext.Current.Request.Url.Host.ToLower();
                var urlHostArray = urlHost.Split('.');
                if (urlHostArray.Length < 3 || RegExp.IsIp(urlHost))
                {
                    return urlHost;
                }
                var urlHost2 = urlHost.Remove(0, urlHost.IndexOf(".", StringComparison.Ordinal) + 1);
                if ((urlHost2.StartsWith("com.") || urlHost2.StartsWith("net.")) || (urlHost2.StartsWith("org.") || urlHost2.StartsWith("gov.")))
                {
                    return urlHost;
                }
                return urlHost2;
            }
        }

        public static string UserIp
        {
            get
            {
                var result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(result))
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                return !RegExp.IsIp(result) ? "Unknown" : result;
            }
        }

        public static string UserDevice
        {
            get
            {
                var result = HttpContext.Current.Request.UserAgent;
                return result;

            }
        }

    }
}
 
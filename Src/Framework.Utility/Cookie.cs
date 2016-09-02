using System;
using System.Runtime.CompilerServices;
using System.Web;

namespace Framework.Utility
{
    public class Cookie
    {
        public static HttpCookie Get(string name)
        {
            return HttpContext.Current.Request.Cookies[name];

        }

        public static string GetValue(string name)
        {
            var httpCookie = Get(name);
            if (httpCookie != null)
            {
                return httpCookie.Value;
            }
            return String.Empty;
        }

        public static void Remove(string name)
        {
            Cookie.Remove(Cookie.Get(name));
        }

        public static void Remove(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now;
                Cookie.Save(cookie);
            }
        }

        public static void Save(string name, string value, int expireHours = 0)
        {
            var httpCookie = Get(name);
            if (httpCookie == null)
            {
                httpCookie = Set(name);
            }
            httpCookie.Value = value;
            Cookie.Save(httpCookie,expireHours);
        }

        public static void Save(HttpCookie cookie, int expiresHours = 0)
        {
            var domain = Fetch.ServerDomain;
            var urlHost = HttpContext.Current.Request.Url.Host.ToLower();
            if (domain != urlHost)
            {
                cookie.Domain = domain;
            }
            if (expiresHours > 0)
            {
                cookie.Expires = DateTime.Now.AddHours(expiresHours);
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static HttpCookie Set(string name)
        {
            return  new HttpCookie(name);
        }
    }
}
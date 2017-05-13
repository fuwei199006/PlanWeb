using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Routing;
using Core.Cache;
using Core.Config;
using DevTrends.MvcDonutCaching;
using Framework.Utility;
using Newtonsoft.Json;

namespace Core.Module
{
    public abstract class ContextCollectHandler:IHttpHandler, IRouteHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.Clear();
            response.ContentEncoding=Encoding.Default;

            if (!string.Equals(Fetch.ServerDomain, "localhost", StringComparison.OrdinalIgnoreCase))
            {
                response.Write(" <h1> 非法访问收集数据！</h1> ");
            }
            else
            {
                ProcessRequest(request,response);
            }
            response.Flush();
            response.End();
            response.Close();
           
        }
        public abstract void ProcessRequest(HttpRequest req, HttpResponse res);
        public bool IsReusable { get; set; }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }

    public class ConfigCollect:ContextCollectHandler
    {
        public override void ProcessRequest(HttpRequest req, HttpResponse res)
        {
            var type = typeof (LocalCachedConfigContext);
            var configContext = LocalCachedConfigContext.Current;

            if (string.IsNullOrEmpty(req["config"]))
            {
                res.Write("<p><h1>网站当前配置列表：</h1><p>");

                foreach (var p in type.GetProperties())
                {
                    if (p.Name != "ConfigService")
                        res.Write(string.Format("<p><a href='?config={0}' target='_blank'>{0} [点击查看]</a></p>", p.Name));
                }
            }
            else
            {
                foreach (var p in type.GetProperties())
                {
                    if (p.Name == req["config"] && p.Name != "DaoConfig")
                    {
                        var curreConfig = p.GetValue(configContext, null);
                        if (configContext != null)
                        {
                            res.ContentType = "text/xml";
                            res.ContentEncoding=Encoding.Default;
                            res.Write(SerializationHelper.XmlSerialize(curreConfig));
                            break;
                        }
                    }
                }
            }

        }

    }

    public class CacheCollect : ContextCollectHandler
    {
        public override void ProcessRequest(HttpRequest req, HttpResponse res)
        {
            if (req.QueryString.Count == 0)
            {
                res.Write("<p><h1>当前网站缓存列表</h1></p>");
                var cacheItemList=new List<string>();
                 
                var s = string.Format("<a href='?cacheClear=true' target='_blank'>[!点击清除所有缓存]</a>&nbsp&nbsp本地缓存百分比：{0}%&nbsp&nbsp本地剩余缓存空间:{1}MB", HttpRuntime.Cache.EffectivePercentagePhysicalMemoryLimit,Decimal.Round(decimal.Parse(HttpRuntime.Cache.EffectivePrivateBytesLimit.ToString())/(1024*1024),2));
                cacheItemList.Add(s);

                var cacheEnumerator = HttpRuntime.Cache.GetEnumerator();
                while (cacheEnumerator.MoveNext())
                {
                    var key = cacheEnumerator.Key.ToString();
                    s = string.Format("<b>{0}</b>:(<a href='?key={0}' target='_blank'>查看数据</a>)", key);
                    cacheItemList.Add(s);

                }
                cacheItemList.Sort();
                res.Write(string.Join("<hr>",cacheItemList));

            }
            else
            {
                if (req["cacheClear"] != null)
                {
                    CacheContext.Clear();
                    var cacheManager = new OutputCacheManager();//？？？清除缓存这个为什么？？？
                    cacheManager.RemoveItems();
                    HttpContext.Current.Items.Clear();
                    res.Write("清除缓存成功！<a href='javascript:window.close();'>[!点击关闭]</a>");
                }
                if (req["key"] != null)
                {
                    var data = CacheContext.Get(req["key"]);
                    if (data != null)
                    {
                        res.Write(JsonConvert.SerializeObject(data)+ string.Format("&nbsp<a href='?key={0}&singleCache=true'>[!点击清除缓存]</a>",req["key"]));
                    }
                    if (req["singleCache"] != null)
                    {
                        CacheContext.Remove(req["key"]);
                        res.Clear();
                        res.Write("清除缓存成功！<a href='javascript:window.close();'>[!点击关闭]</a>");
                    }
                }
            }
        }

        
    }

    public class LogCollect:ContextCollectHandler
    {
        public override void ProcessRequest(HttpRequest req, HttpResponse res)
        {
            throw new NotImplementedException();
        }
    }
}
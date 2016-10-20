using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Framework.Contract;
using Framework.Utility;
using Newtonsoft.Json;

namespace Framework.Web
{
    public class ControllerBase : Controller
    {
        public virtual Operater Operater
        {
            get
            {
                return null;
            }

        }

        public virtual int PageSize
        {
            get { return 15; }
        }

        protected ContentResult JsonP(string callback, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return this.Content(String.Format("{0}({1})", callback, json));
        }

        /// <summary>
        /// 弹出DIV 需要刷新浏览器整个页面
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public ContentResult RefreshParent(string alert = null)
        {
            var script = string.Format("<script>{0};parent.location.reload(1)</script>",
                string.IsNullOrEmpty(alert) ? string.Empty : "alert('" + alert + "')");
            return this.Content(script);
        }

        public new ContentResult RefreshParentTab(string alert = null)
        {
            var script =
             string.Format("<script>{0}; if (window.opener != null) {{ window.opener.location.reload(); window.opener = null;window.open('', '_self', '');  window.close()}} else {{parent.location.reload(1)}}</script>",
             string.IsNullOrEmpty(alert) ? string.Empty : "alert('" + alert + "')");
            return this.Content(script);

        }
        /// <summary>
        /// 用JS关闭弹窗
        /// </summary>
        /// <returns></returns>
        public ContentResult CloseThickbox()
        {
            return this.Content("<script>top.tb_remove()</script>");
        }

        /// <summary>
        ///  警告并且历史返回
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public ContentResult Back(string notice)
        {
            var content=new StringBuilder("<script>");
            if (!string.IsNullOrEmpty(notice))
            {
                content.AppendFormat("alert('{0}');", notice);
            }
            content.Append("<history.go(-1)</script>");
            return this.Content(content.ToString());
        }

        public ContentResult PageReturn(string msg, string url = null)
        {
            var content=new StringBuilder("<script type='text/javascript'>");
            if (!string.IsNullOrEmpty(msg))
            {
                content.AppendFormat("alert('{0}')", msg);
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                url = Request.Url.ToString();
            }
            content.Append("window.location.href='" + url + "'</script>");
            return this.Content(content.ToString());
        }

        public ContentResult Stop(string notice, string redirect, bool isAlert = false)
        {
            var content = "<meta http-equiv='refresh' content='1;url=" + redirect + "' /><body style='margin-top:0px;color:red;font-size:24px;'>" + notice + "</body>";

            if (isAlert)
                content = string.Format("<script>alert('{0}'); window.location.href='{1}'</script>", notice, redirect);

            return this.Content(content);
        }
        /// <summary>
        /// 在方法执行前更新操作人
        /// </summary>
        /// <param name="filterContext"></param>
        public virtual void UpdateOperater(ActionExecutingContext filterContext)
        {
            if (this.Operater == null)
            {
                return;
            }
            WcfContext.Current.Operater = this.Operater;
        }
        public virtual void ClearOperater()
        {
            
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest() && !filterContext.IsChildAction)
            {
                RenderViewData();
            }
            this.ClearOperater();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.UpdateOperater(filterContext);
            base.OnActionExecuting(filterContext);

            //在方法执行前，附加上PageSize值
            filterContext.ActionParameters.Values.Where(r => r is Request)
                .ToList()
                .ForEach(v => ((Request) v).PageSize = this.PageSize);
        }

        /// <summary>
        /// 产生一些视图数据
        /// </summary>
        protected virtual void RenderViewData()
        {
        }

        public WebExceptionContext WebExceptionContext
        {
            get
            {
                var exceptionContext=new WebExceptionContext()
                {
                    IP = Fetch.UserIp,
                   CurrentUrl = Fetch.CurrentUrl,
                   RefUrl = (Request==null||Request.UrlReferrer==null)?string.Empty:Request.UrlReferrer.AbsoluteUri,
                   IsAjaxRequest = Request != null && Request.IsAjaxRequest(),
                   FormData = Request==null?null:Request.Form,
                   QueryData = Request==null?null:Request.QueryString,
                   RouteData = (Request==null||Request.RequestContext==null||Request.RequestContext.RouteData==null)?null:Request.RequestContext.RouteData.Values

                };
                return exceptionContext;
            }
        }

        /// <summary>
        /// 发生异常写Log
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var e = filterContext.Exception;

            LogException(e, this.WebExceptionContext);
        }

        protected virtual void LogException(Exception exception, WebExceptionContext exceptionContext = null)
        {
            //do nothing!
        }

    }


        public class WebExceptionContext
    {
        public string IP { get; set; }
        public string CurrentUrl { get; set; }
        public string RefUrl { get; set; }
        public bool IsAjaxRequest { get; set; }
        public NameValueCollection FormData { get; set; }
        public NameValueCollection QueryData { get; set; }
        public RouteValueDictionary RouteData { get; set; }
    }
}
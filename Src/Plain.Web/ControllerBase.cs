
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core.Config;
using Framework.Contract;
using Framework.Web;
using Plain.Dto;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Linq;
using Framework.Utility;
using System.Web.Routing;
using System.Data.SqlClient;
using Core.Cache;
using Core.Exception;

namespace Plain.Web
{
    public abstract class ControllerBase : Framework.Web.ControllerBase
    {

        [PermessionIgnore]
        [AuthorizeIgnore]
        public ActionResult Error()
        {
            string error = Request["error"];
            int code = Request["code"] == null ? 500 : int.Parse(Request["code"]);
            return TError(error, code);
        }


        [PermessionIgnore]
        [AuthorizeIgnore]
        public ActionResult TError(string error, int code, int isFull = 0)
        {

            ViewData["code"] = code;
            ViewData["error"] = string.Empty;
#if DEBUG
            ViewData["error"] = error;
#endif
            if (Request.UrlReferrer != null && Fetch.ServerDomain == Request.UrlReferrer.Host && isFull != 1)
            {
                return View("Error");
            }
            return View("ErrorFull");


        }
        [PermessionIgnore]
        [AuthorizeIgnore]
        [ValidateInput(false)]
        public ActionResult SkipAndInfo(string msg, MsgType type, bool isAutoSkip, string skipUrl)
        {
            ViewBag.ErrorMsg = msg;
            ViewBag.MsgType = type;
            ViewBag.IsAutoSkip = isAutoSkip;
            ViewBag.SkipUrl = skipUrl;
            return View("Info");
        }
        [PermessionIgnore]
        [AuthorizeIgnore]
        public ActionResult SkipAndAlert(string msg, MsgType type)
        {
            ViewBag.ErrorMsg = msg;
            ViewBag.MsgType = type;
            ViewBag.IsAutoSkip = false;
            return View("Info");
        }
        [PermessionIgnore]
        [AuthorizeIgnore]
        public ActionResult SkipAndAlert(string msg, MsgType type, bool isAutoSkip, string skipUrl)
        {
            ViewBag.ErrorMsg = msg;
            ViewBag.MsgType = type;
            ViewBag.IsAutoSkip = true;
            ViewBag.SkipUrl = skipUrl;
            return View("Info");
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            //todo:如果数据库的连接出错，可能会有空白的现象
            //ViewData["code"] = 500;
            var error = string.Empty;
#if DEBUG
            error = filterContext.Exception.Message;
#endif
            if (filterContext.Exception is SqlException)
            {
                filterContext.Result = TError(error, 500, 1);
            }
            else
            {
                filterContext.Result = TError(error, 500);
            }

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sysAdmins = LocalCachedConfigContext.Current.SystemConfig.SysAdmin == null ? new List<string>() : LocalCachedConfigContext.Current.SystemConfig.SysAdmin.Split(';').Where(r => !string.IsNullOrEmpty(r));
            var noPermessionIgnore = filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermessionIgnoreAttribute), false);
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
            //系统关闭，只有超级管理员能打开
            if (!sysAdmins.Contains(LoginInfo.LoginNickName) 
                && !LocalCachedConfigContext.Current.SystemConfig.Runable 
                && noPermessionIgnore.Length == 0 
                && noAuthorizeAttributes.Length == 0)
            {
                throw new RunableException();
            }

            /**
             * 这里是先验证登录，如果当前Action忽略了登录验证，也不会进行权限的验证
             * 2016.12.02
             * fuwei
             * */
          
            if (noAuthorizeAttributes.Length > 0)
                return;
            base.OnActionExecuting(filterContext);
            if (this.LoginInfo == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login", new { Area = "Auth" });
                return;
            }


            #region 菜单的验证
            if (!sysAdmins.Contains(LoginInfo.LoginNickName))
            {
         
                var urlList = AdminMenuCache.Current.Menus.Select(x => x.MenuUrl);
                if (!urlList.Contains(Request.Url.AbsolutePath.ToString()) && noPermessionIgnore.Length == 0)
                {
                    if (Request["id"] != null)
                    {
                        filterContext.Result = this.FrameStop("没有权限,3秒后自动刷新");
                    }
                    else
                    {
                        filterContext.Result = this.Stop("没有权限,3秒后自动刷新", Url.Action("Index", "Home"));
                    }

                    return;
                }
            }
      
            #endregion

        }
        public AdminCookieContext CookieContext
        {
            get
            {
                return AdminCookieContext.Current;
            }
        }


        public AdminUserContext UserContext
        {
            get
            {
                return AdminUserContext.Current;
            }
        }


        public LocalCachedConfigContext ConfigContext
        {
            get
            {
                return LocalCachedConfigContext.Current;
            }
        }


        public virtual Basic_LoginInfo LoginInfo
        {
            get
            {
                return UserContext.LoginInfo;
            }
        }

        public static AdminCacheContext AdminCacheContext
        {
            get
            {
                return AdminCacheContext.Current;
            }
        }



        public override int PageSize
        {
            get { return 10; }
        }


        public override Operater Operater
        {
            get
            {
                var loginInfo = this.LoginInfo;//测试下是否多次访问,使用变量缓存。性能会好 
                return new Operater
                {
                    Name = loginInfo == null ? "" : loginInfo.LoginName,
                    IP = loginInfo == null ? "" : loginInfo.LoginIp,
                    Token = loginInfo == null ? Guid.Empty : loginInfo.LoginToken,
                    UserId = loginInfo == null ? 0 : loginInfo.LoginUserId,
                    Time = DateTime.Now

                };
            }
        }

        public virtual Guid UserToken
        {
            get { return CookieContext.UserToken; }
        }

    }
}

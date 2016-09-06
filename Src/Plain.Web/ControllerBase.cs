 
using System;
using System.Web.Mvc;
using Core.Config;
using Framework.Contract;
using Framework.Web;
using Plain.Dto;
using Plain.Model.Models;

namespace Plain.Web
{
    public abstract class ControllerBase:Framework.Web.ControllerBase
    {

        [ValidateInput(false)]
        public ActionResult Info(string msg, MsgType type)
        {
            ViewBag.ErrorMsg = msg;
            ViewBag.MsgType = type;
            ViewBag.IsAutoSkip = false;
            ViewBag.SkipUrl = "";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult SkipAndInfo(string msg, MsgType type, bool isAutoSkip, string skipUrl)
        {
            ViewBag.ErrorMsg = msg;
            ViewBag.MsgType = type;
            ViewBag.IsAutoSkip = isAutoSkip;
            ViewBag.SkipUrl = skipUrl;
            return View("Info");
        }

        public ActionResult SkipAndAlert(string msg, MsgType type)
        {
            return RedirectToAction("Info", new { msg, type });
        }
        public ActionResult SkipAndAlert(string msg, MsgType type, bool isAutoSkip, string skipUrl)
        {
            return RedirectToAction("SkipAndInfo", new { msg, type, isAutoSkip, skipUrl });
        }


        protected override void OnException(ExceptionContext filterContext)
        {
           
            SkipAndAlert("系统出错，先休息一下吧！<br/>错误信息:"+filterContext.Exception.Message, MsgType.Error, true, Url.Action("Register"));
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
            if (noAuthorizeAttributes.Length > 0)
                return;
            base.OnActionExecuting(filterContext);
            if (this.LoginInfo == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
                return;
            }
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

        public override int PageSize
        {
            get { return 15; }
        }


        public override Operater Operater
        {
            get
            {
                return new Operater
                {
                    Name = this.LoginInfo == null ? "" : LoginInfo.LoginName,
                    IP = this.LoginInfo == null ? "" : LoginInfo.LoginIp,
                    Token = this.LoginInfo == null ? Guid.Empty : LoginInfo.LoginToken,
                    UserId = this.LoginInfo == null ? 0 : LoginInfo.LoginUserId,
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

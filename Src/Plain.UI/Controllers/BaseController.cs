using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Core.Config;
using Framework.Contract;
using Framework.Web;
using Plain.Dto;
using Plain.Model.Models;
using Plain.Web;

namespace Plain.UI.Controllers
{
    public class BaseController : Plain.Web.ControllerBase
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
            if (noAuthorizeAttributes.Length > 0)
                return;
            base.OnActionExecuting(filterContext);
            if (this.LoginInfo == null)
            {
                filterContext.Result = RedirectToAction("Login", "Login");
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


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
 
    }
}
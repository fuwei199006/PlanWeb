using System;
using System.Web.Mvc;

namespace Framework.Web
{
    public class AuthorizeFilterAttribute:ActionFilterAttribute
    {
        public string Name { get; set; }

        public AuthorizeFilterAttribute(string name)
        {
            this.Name = name;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!this.Authorize(filterContext, this.Name))
                filterContext.Result = new ContentResult { Content = "<script>alert('抱歉,你不具有当前操作的权限！');history.go(-1)</script>" };
        }

        protected virtual bool Authorize(ActionExecutingContext filterContext, string permissionName)
        {
            if (filterContext.HttpContext == null)
            {
                throw  new ArgumentException("httpContext");
            }

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            return true;
        }

       
    }
}
using System.Web;
using System.Web.Mvc;
using Plain.Web;

namespace Plain.CMS.ActionFilters
{
    public class SingalLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
            /**
             * 1. 获得当前的cookie信息
             * 2. 取得token,调用api登录系统。
             * 3. 存储当前的登录信息。
             * */

            //var userNamer=AdminCookieContext.Current.UserName;
            //var userId=AdminCookieContext.Current.UserId;
            //var token = HttpContext.Current.Request["token"];
            //if (!string.IsNullOrEmpty(token))
            //{
                
            //}




        }
    }
}
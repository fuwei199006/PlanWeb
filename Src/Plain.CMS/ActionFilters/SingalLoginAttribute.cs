using System.Web;
using System.Web.Mvc;

namespace Plain.UI.ActionFilters
{
    public class SingalLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             
                base.OnActionExecuting(filterContext);
                var token = HttpContext.Current.Request["token"];
                //if (!string.IsNullOrEmpty(token))
                //{

                //}


           
       
        }
    }
}
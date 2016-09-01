using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Framework.Web;
using Plain.Dto;

namespace Plain.UI.Controllers
{
    public class BaseController :Plain.Web.ControllerBase
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                    var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
                    if (noAuthorizeAttributes.Length > 0)
                          return;
                    base.OnActionExecuting(filterContext);
        }
    }
}
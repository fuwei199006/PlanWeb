using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Framework.Web
{
    /// <summary>
    /// 用于权限点认证，标记在Action上面
    /// </summary>
    public class PermissionAttribute : FilterAttribute, IActionFilter
    {
        public List<Basic_Power> Permissions { get; set; }

        public PermissionAttribute(params Basic_Power[] parameters)
        {
            Permissions = parameters.ToList();
        }
        public PermissionAttribute()
        {
            Permissions = null;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Permissions == null)
            {
                return;
            }
         
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}

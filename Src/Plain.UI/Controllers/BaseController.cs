using System;

namespace Plain.UI.Controllers
{
    public class BaseController : Plain.Web.ControllerBase
    {

        protected void SetDropEnumViewData<T>(string key) where T :struct 
        {
            ViewData[key]=AdminCacheContext.AdminMainDataContext.GetSelectListItems<T>(key);
        }

        protected void SetDicEnumViewData<T>(string key) where T : struct
        {
            ViewData[key] = AdminCacheContext.AdminMainDataContext.GetItemValueList<T>(key);
        }
    }
}
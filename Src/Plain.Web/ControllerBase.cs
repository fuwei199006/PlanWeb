 
using System.Web.Mvc;
using Plain.Dto;

namespace Plain.Web
{
    public abstract class ControllerBase:Framework.Web.ControllerBase
    {
        public const string yes = "yes";
        public const string no = "no";

          

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
    }
}

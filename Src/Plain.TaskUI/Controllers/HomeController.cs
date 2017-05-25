using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Plain.TaskUI.Controllers
{
    public class HomeController : AsyncController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public  string  GetVersion()
        {
            return "5.0.0.0";
        }

        public JsonResult GetZips()
        {
            return Json(new []
            {
                "1.zip",
                "2.zip",
                "3.zip",
            },JsonRequestBehavior.AllowGet);
        }

        public string  GetDownLoadUrl()
        {

            return "http://localhost:8066/";
        }
    }
}
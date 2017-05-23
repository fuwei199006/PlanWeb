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

        public Task<string> Test()
        {
            var c = "testc";
            var task= Task.Factory.StartNew(() =>
                {

                })
                .ContinueWith<string>(x => c) ;
            c = "test12345";
            return task;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.UI.Areas.Auth.Controllers;
using Framework.Web;

namespace Plain.UI.Controllers
{
    public class HomeController : BaseController
    {

 
        [PermessionIgnore]
        // GET: Home
        public ActionResult Index(string error)
        {
              return View();
        }
    }
}
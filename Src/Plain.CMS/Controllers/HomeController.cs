using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Plain.CMS.Controllers
{
    public class HomeController : Plain.Web.ControllerBase
    {
        public ActionResult Get()
        {
            return View();
        }
    }
}
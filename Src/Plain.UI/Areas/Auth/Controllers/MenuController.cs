using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.UI.Controllers;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Auth/Menu
        public ActionResult Index()
        {
            return View();
        }
    }
}
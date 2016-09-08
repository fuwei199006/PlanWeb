using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Web;
using Plain.UI.Controllers;

namespace Plain.UI.Areas.CMS.Controllers
{
    public class CmsHomeController : BaseController
    {
        [AuthorizeIgnore]
        // GET: CMS/CmsHome
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
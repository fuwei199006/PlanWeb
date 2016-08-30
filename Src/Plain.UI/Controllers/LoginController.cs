using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.BLL.LoginService;

namespace Plain.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            _loginService.LoginOut("fuwei");
            return View();
        }
    }
}
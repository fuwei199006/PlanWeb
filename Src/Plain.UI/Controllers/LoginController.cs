using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.BLL.LoginService;
using Plain.Model.Models;

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
            return View();
        }

        [HttpPost]
        public ActionResult Register(Basic_Register register)
        {
            if (true)
                return RedirectToAction("Index", "Home");
        }
    }
}
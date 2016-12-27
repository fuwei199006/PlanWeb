using Plain.BLL.LoginService;
using Plain.BLL.UserService;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plain.UI.Areas.PlanApi.Controllers
{
    public class LoginApiController : ApiController
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;


        public LoginApiController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }


        //[HttpPost]
        public Basic_LoginInfo GetLoginInfoByToken(string token)
        {
            return _loginService.GetLoginInfoByToken(Guid.Parse(token));
        }


    }
}

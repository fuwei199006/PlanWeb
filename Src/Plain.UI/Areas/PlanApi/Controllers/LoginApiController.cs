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
        // GET: api/LoginApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public  Basic_LoginInfo  GetLoginInfoByToken(string token)
        {
            return _loginService.GetLoginInfoByToken(Guid.Parse(token));
        }

        public IEnumerable<string> Get([FromBody]string value)
        {
            return new string[] { "value1", "value2", value };
        }

        // POST: api/LoginApi
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/LoginApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginApi/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.BLL.UserService;
using Plain.Dto.Request;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Auth/User
        public ActionResult Index(UserRequest userRequest)
        {
            var userPageList = _userService.GetUserByPage(userRequest.LoginName, userRequest.PageSize,
                userRequest.PageIndex);
            return View(userPageList);
        }
    }
}
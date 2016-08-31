using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Encrypt;
using Core.Message;
using Framework.Utility;
using Newtonsoft.Json;
using Plain.BLL.LoginService;
using Plain.BLL.RegisterService;
using Plain.BLL.UserService;
using Plain.Model.Models;

namespace Plain.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IUserService _userService;
        
        public LoginController(ILoginService loginService, IRegisterService registerService, IUserService userService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _userService = userService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            var register = _registerService.GetRegisterByToken(token);
            if (register.Expiretime < DateTime.Now)
            {
                //跳转到错误页面，已经过期
                return RedirectToAction("Error");
            }
            //如果没有过期则，生成用户和登录信息
            var user = new Basic_UserInfo
            {
                LoginName = register.RegisterEmail,
                UserEmail = register.RegisterEmail,
                NickName = register.RegisterName,
                UserPwd = register.RegisterPassword,
                RegisterDevice = RequestHelper.GetDeviceJson(Request.UserAgent),
                RegisterIp = register.RetisterIp, 
                RegisterTime = register.RegisterTime,
                ModifyTime = DateTime.Now,
                CreateTime = DateTime.Now,
                UserStaus = 1
            };
            var result=_userService.AddUser(user);
            if (result != null)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public ActionResult Register(Basic_Register register)
        {
            register.CreateTime=DateTime.Now;
            register.Expiretime = DateTime.Now.AddDays(7);
            register.RetisterIp = Fetch.UserIp;
            register.RegisterDevice = RequestHelper.GetDeviceJson(Request.UserAgent);
            register.RegisterPassword = MD5Encrypt.Md5(register.RegisterPassword);
            register.RegisterConfirmPassword = register.RegisterPassword;
            register.RegisterTime=DateTime.Now;
            register.RegisterStatus = true;
            register.RegisterPhone = "NaN";//代表没有手机号
            register.RegisterToken = Guid.NewGuid();
            try
            {
                var result = _registerService.AddRegister(register);
                MailContext.SendEmail(result.RegisterEmail, "Plain平台注册", @"<meta charset='utf-8'/><body><p>Plain 模板测试 </p><p> 点击下面的链接完成注册："+Request.Url+"?token="+register.RegisterToken.ToString()+"</p></body> ");

                return RedirectToAction("Index", "Home");
                
            }
            catch (DbEntityValidationException e)
            {
                var er = e;
                return RedirectToAction("Error");
            }
           
        }


        
        [HttpGet]
        public JsonResult ValideUser(string RegisterEmail)
        {
            var result = _userService.GetUserByEmail(RegisterEmail);
            if (result == null) return Json(true, JsonRequestBehavior.AllowGet); 
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}
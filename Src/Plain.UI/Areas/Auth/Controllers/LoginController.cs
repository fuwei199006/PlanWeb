using System;
using System.Web.Mvc;
using Core.Encrypt;
using Core.Message;
using Framework.Utility;
using Framework.Utility.ValideCode;
using Framework.Web;
using Plain.BLL.LoginService;
using Plain.BLL.RegisterService;
using Plain.BLL.UserService;
using Plain.Dto;
using Plain.Model.Models;
using Plain.UI.Controllers;
using Plain.Model.Models.Model;
using Plain.BLL.MenuService;
using System.Threading;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;

        public LoginController()
        {

        }
        public LoginController(ILoginService loginService, IRegisterService registerService, IUserService userService, IMenuService menuService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _userService = userService;
            _menuService = menuService;
        }

        // GET: Login
        [AuthorizeIgnore]
        public ActionResult Index()
        {

            return View();
        }
        [AuthorizeIgnore]
        public ActionResult Register(string token)
        {


            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            var register = _registerService.GetRegisterByToken(token);
            if (register == null)
            {
                //跳转到错误页面，已经过期
                return SkipAndAlert("注册信息不存在，请先注册,3秒后自动跳转注册页面", MsgType.Error, true, Url.Action("Register"));
            }
            if (register.Expiretime < DateTime.Now)
            {
                //跳转到错误页面，已经过期
                return SkipAndAlert("注册信息已经过期，请重新注册,3秒后自动跳转注册页面", MsgType.Error, true, Url.Action("Register"));
            }
            //如果没有过期则，生成用户和登录信息
            var result = _userService.ActiveUserByEmail(register.RegisterEmail);
            _registerService.DeleteRegister(token);
            if (result == null)
            {
                return SkipAndAlert("重复注册，请直接登录！", MsgType.Error);
            }
            if (result != null)
            {

                return SkipAndAlert("注册成功,欢迎您的加入!", MsgType.Success, true, Url.Action("Index", "Home"));
            }

            return SkipAndAlert("系统出错，先休息一下吧！", MsgType.Error);
        }

        [HttpPost]
        [AuthorizeIgnore]
        public ActionResult Register(Basic_Register register, string valideCode)
        {
            if (string.IsNullOrEmpty(valideCode))
            {
                ModelState.AddModelError("valideCode", "验证码不能为空");
                return View();
            }


            if (!valideCode.Equals(this.CookieContext.VerifyCode))
            {
                ModelState.AddModelError("valideCode", "验证码不正确");
                return View();
            }

            register.CreateTime = DateTime.Now;
            register.Expiretime = DateTime.Now.AddDays(7);
            register.RetisterIp = Fetch.UserIp;
            register.RegisterDevice = RequestHelper.GetDeviceJson(Request.UserAgent);
            register.RegisterPassword = MD5Encrypt.Md5(register.RegisterPassword);
            register.RegisterConfirmPassword = register.RegisterPassword;
            register.RegisterTime = DateTime.Now;
            register.RegisterStatus = true;
            register.RegisterPhone = "NaN";//代表没有手机号
            register.RegisterToken = Guid.NewGuid();

            var result = _registerService.AddRegister(register);
            var existUser = _userService.EmailExist(result.RegisterEmail);
            if (existUser == null)//防止重复注册
            {
                var user = new Basic_UserInfo
                {
                    LoginName = register.RegisterEmail,
                    UserEmail = register.RegisterEmail,
                    NickName = register.RegisterName,
                    UserPwd = register.RegisterPassword,
                    ModifyTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    UserStaus = (int)UserStausType.Disable,
                };
                _userService.AddUser(user);
            }

            var sentRes = MailContext.SendEmail(result.RegisterEmail, "Plain平台注册", @"<meta charset='utf-8'/><body><p>Plain 模板测试 </p><p> 点击下面的链接完成注册：" + Request.Url + "?token=" + result.RegisterToken.ToString() + "</p></body> ");
            if (sentRes)
            {
                return SkipAndAlert("注册成功,系统已经将激活邮件发送到您的邮箱，请查收！", MsgType.Success);
            }

            return SkipAndAlert("系统出错，先休息一下吧！", MsgType.Error);



        }

        [AuthorizeIgnore]
        [HttpPost]
        public ActionResult Login(string loginName, string password, string valideCode)
        {
            if (string.IsNullOrEmpty(valideCode))
            {
                ModelState.AddModelError("valideCode", "验证码不能为空");
                return View("Index");
            }

            //todo:全部修改成资源文件。
            var user = _userService.GetUserByEmail(loginName);
            if (user == null)
            {
                ModelState.AddModelError("valideCode", "用户不存在");
                return View("Index");
            }
            else
            {
                if (user.UserStaus == (int)UserStausType.Lock)
                {
                    ModelState.AddModelError("valideCode", "用户账号已经被锁定，请联系管理员wells_services@163.com");
                    return View("Index");
                }
                else if (user.UserStaus != (int)UserStausType.Active)
                {
                    ModelState.AddModelError("valideCode", "用户账号尚未激活，如有疑问请联系，请联系管理员wells_services@163.com");
                    return View("Index");
                }
            }
            var loginInfo = this._loginService.Login(loginName, password);
            if (loginInfo != null)
            {
                this.CookieContext.UserToken = loginInfo.LoginToken;
                this.CookieContext.UserName = loginInfo.LoginName;
                this.CookieContext.UserId = loginInfo.LoginUserId;
                return RedirectToAction("Index", "Home");
            }
            this.CookieContext.LoginErrorTimes++;
            if (this.CookieContext.LoginErrorTimes > 5)
            {
                //登录错误大于5次，账号锁定
                _userService.LockUser(user.Id);
            }
            ModelState.AddModelError("valideCode", "用户名或密码不正确");
            return View("Index");
        }

        [AuthorizeIgnore]
        [HttpGet]
        public JsonResult ValideUser(string RegisterEmail)
        {
            var result = _userService.GetUserByEmail(RegisterEmail);
            if (result == null) return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeIgnore]
        public ActionResult VerifyImage()
        {
            var s1 = new ValidateCode_Style1();
            string code = "6666";
            byte[] bytes = s1.CreateImage(out code);

            this.CookieContext.VerifyCode = code;

            return File(bytes, @"image/jpeg");

        }


        [AuthorizeIgnore]
        public ActionResult LoginOut()
        {
            this._loginService.LoginOut(this.CookieContext.UserToken);
            this.CookieContext.UserToken = Guid.Empty;
            this.CookieContext.UserName = string.Empty;
            this.CookieContext.UserId = 0;
            return RedirectToAction("Index");
        }
        [PermessionIgnore]
        public string GetOnlinePerson(int onlineCount)
        {
            var online = this._loginService.GetOnlineUser().Count;

            while (online == onlineCount)
            {
                online = this._loginService.GetOnlineUser().Count;
                Thread.Sleep(1000);
            }
            return online.ToString();

        }

    }
}
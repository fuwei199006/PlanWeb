using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Encrypt;
using Plain.BLL.UserService;
using Framework.Utility;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using Plain.Dto.Request;
using Plain.Dto;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class UserController : BaseController
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

        public ActionResult Edit(int id)
        {
            ViewData["UserStatus"] = EnumHelper.GetItemValueList<UserStausType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            ViewData["Sex"] = EnumHelper.GetItemValueList<SexType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value

            });
            var user = _userService.GetUserByUserId(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollect)
        {

            var user = _userService.GetUserByUserId(id);
            TryUpdateModel(user);
            user.ModifyTime = DateTime.Now;
            this._userService.UpdateUser(user);
            return this.RefreshParent();
        }

        public ActionResult Create()
        {
            ViewData["UserStatus"] = EnumHelper.GetItemValueList<UserStausType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            ViewData["Sex"] = EnumHelper.GetItemValueList<SexType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            ViewData["UserStatus"] = EnumHelper.GetItemValueList<UserStausType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            ViewData["Sex"] = EnumHelper.GetItemValueList<SexType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value

            });
            var user = new Basic_UserInfo();
            TryUpdateModel(user);
            user.LoginName = user.RealName;
            user.NickName = user.RealName;
            user.UserPwd = MD5Encrypt.Md5("111111");
            user.ModifyTime = DateTime.Now;
            user.CreateTime = DateTime.Now;
            this._userService.AddUser(user);
            return this.RefreshParent();
        }

        public ActionResult Delete(List<int> ids)
        {
            this._userService.DeleteUser(ids);
            return RedirectToAction("Index"); 
        }

        public ActionResult Detail(int id)
        {
            var user = _userService.GetUserByUserId(id);
            return View(user);
        }
    }
}
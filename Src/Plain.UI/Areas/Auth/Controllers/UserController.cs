﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plain.BLL.UserService;
using Plain.Dto.Request;
using Framework.Utility;
using Plain.Dto;
using Plain.UI.Controllers;

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
                Value = x.Key.ToString(),Text=x.Value
                
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
        public ActionResult Edit(int id,FormCollection formCollect)
        {
            
            var user = _userService.GetUserByUserId(id);
            TryUpdateModel(user);
            user.ModifyTime = DateTime.Now;
            this._userService.UpdateUser(user);
            return this.RefreshParent();  
        }
    }
}
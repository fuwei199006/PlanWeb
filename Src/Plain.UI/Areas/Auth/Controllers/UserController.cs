using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Encrypt;
using Plain.BLL.UserService;
using Framework.Utility;
using Plain.BLL.RoleService;
using Plain.BLL.UserRoleService;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using Plain.Dto.Request;
using Plain.Dto;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        // GET: Auth/User
        public ActionResult Index(UserRequest userRequest)
        {
            var userPageList = _userService.GetUserByPage(userRequest.LoginName, userRequest.PageSize,
                userRequest.PageIndex);
             foreach(var user in userPageList)
            {
                user.Roles = _userService.GetUserByUserId(user.Id).Roles;
            }
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
            ViewData["SexDrop"] = EnumHelper.GetItemValueList<SexType>().Select(x => new SelectListItem
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

        public ActionResult RoleList(int id)
        {
            var user = _userService.GetUserByUserId(id);
            var roleList = _roleService.GetRoleList();
            ViewBag.Group = EnumHelper.GetItemValueList<RoleGroup>();
            ViewBag.role = roleList;
            return View(user);
        }

        [HttpPost]
        public ActionResult RoleList(int id,List<int> RoleIds)
        {
            _userRoleService.DeleteUserRoles(id);
            var userRoleList = RoleIds.Select(x => new Basic_UserRole
            {
                UserId = id,
                RoleId = x,
                MappingStatus = true,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            }).ToList();
            _userRoleService.AddUserRole(userRoleList);
            return this.RefreshParent();
        }
    }
}
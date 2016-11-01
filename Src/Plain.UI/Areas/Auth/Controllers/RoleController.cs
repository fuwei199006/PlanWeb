using Framework.Utility;
using Plain.BLL.RoleService;
using Plain.Dto;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Auth/Role
        public ActionResult Index(RoleRequest request)
        {
            var roleList = _roleService.GetRoleListByPage(request);
            return View(roleList);
        }

        public ActionResult Edit(int id)
        {
            ViewData["StatusType"] = EnumHelper.GetItemValueList<StatusType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            var role = this._roleService.GetRoleById(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult Edit(int id,FormCollection formCollection)
        {
            var role = this._roleService.GetRoleById(id);
            this.TryUpdateModel<Basic_Role>(role);
            role.ModifyTime = DateTime.Now;
            _roleService.UpdateRole(role);
            return this.RefreshParent();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var role = new Basic_Role();
            this.TryUpdateModel(role);
            role.ModifyTime = DateTime.Now;
            role.CreateTime = DateTime.Now;
            this._roleService.AddRole(role);
            return this.RefreshParent();
        }

        public ActionResult Create()
        {
            ViewData["StatusType"] = EnumHelper.GetItemValueList<StatusType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            return View("Edit");
        }

        public ActionResult Delete(List<int> ids)
        {
            _roleService.DeleteRoles(ids);
            return RedirectToAction("Index");
        }
    }
}
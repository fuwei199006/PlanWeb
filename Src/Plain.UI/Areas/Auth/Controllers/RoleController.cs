using Framework.Utility;
using Plain.BLL.RoleService;
using Plain.Dto;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Plain.BLL.PowerRoleService;
using Plain.BLL.PowerService;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;


        private readonly IPowerService _powerService;

        private readonly IPowerRoleService _powerRoleService;

        public RoleController(IRoleService roleService, IPowerService powerService, IPowerRoleService powerRoleService)
        {
            _roleService = roleService;

            _powerService = powerService;
            _powerRoleService = powerRoleService;
        }

        // GET: Auth/Role
        public ActionResult Index(RoleRequest request)
        {
            var roleList = _roleService.GetRoleListByPage(request);
            return View(roleList);
        }

        public ActionResult Edit(int id)
        {

            SetDropEnumViewData<StatusType>(WebKeys.StatusTypeDrop);
            SetDropEnumViewData<RoleGroup>(WebKeys.RoleGroupDrop);

            var role = this._roleService.GetRoleById(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
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
            SetDropEnumViewData<StatusType>(WebKeys.StatusTypeDrop);
            SetDropEnumViewData<RoleGroup>(WebKeys.RoleGroupDrop);
            return View("Edit");
        }

        public ActionResult Delete(List<int> ids)
        {
            _roleService.DeleteRoles(ids);
            return RedirectToAction("Index");
        }


        public ActionResult PowerList(int id)
        {
            var role = _roleService.GetRoleById(id);
            var powerList = _powerService.GetPowerList();
            SetDicEnumViewData<PowerGroup>(WebKeys.RoleGroupDic);

            ViewBag.Power = powerList;
            return View(role);
        }

        [HttpPost]
        public ActionResult PowerList(int id, List<int> PowerIds)
        {
            _powerRoleService.DeletePowerRoleByRoleId(id);
            if (PowerIds != null)
            {
                var powerRoleList = PowerIds.Select(x => new Basic_PowerRole()
                {
                    RoleId = id,
                    PowerId = x,
                    MappingStatus = true,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                }).ToList();
                _powerRoleService.AddPowerRoleRange(powerRoleList);
            }

            return this.RefreshParent();


        }

    }
}
using Framework.Utility;
using Plain.BLL.MenuService;
using Plain.BLL.PowerMenuService;
using Plain.BLL.PowerService;
using Plain.Dto;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class PowerController : BaseController
    {

        private readonly IPowerService _powerService;
        private readonly IMenuService _menuService;
        private readonly IPowerMenuService _powerMenuService;

        public PowerController(IPowerService powerService, IMenuService menuService, IPowerMenuService powerMenuService)
        {
            _powerService = powerService;
            _menuService = menuService;
            _powerMenuService = powerMenuService;
        }

        // GET: Auth/Power
        public ActionResult Index(PowerRequest request)
        {
            var powerList = _powerService.GetPowerPage(request);
            return View(powerList);
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
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var power = new Basic_Power();
            this.TryUpdateModel(power);
            power.CreateTime = DateTime.Now;
            power.ModifyTime = DateTime.Now;
            this._powerService.AddPower(power);
            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            ViewData["StatusType"] = EnumHelper.GetItemValueList<StatusType>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });

            ViewData["PowerGroupDrop"] = EnumHelper.GetItemValueList<PowerGroup>().Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value.ToString()

            });
            var power = _powerService.GetPowerById(id);
            return View(power);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {

            var power = _powerService.GetPowerById(id);
            this.TryUpdateModel(power);
            power.ModifyTime = DateTime.Now;
            this._powerService.UpdatePower(power);
            return this.RefreshParent();
        }

        public ActionResult Delete(List<int> ids)
        {
            this._powerService.DeletePower(ids);
            return RedirectToAction("Index");
        }

        public string ExecPower()
        {
            try
            {
                _powerMenuService.ClearPowerMenu();
                var powerIds = _powerService.GetPowerList().Select(x => x.Id).ToList();
                _powerService.DeletePower(powerIds);
                var menus = _menuService.GetMenus();
                var powerMenuList = new List<Basic_PowerMenu>();
                foreach (var item in menus)
                {
                    var power = new Basic_Power()
                    {
                        PoweName = item.MenuName + "权限",
                        PowerGroup = ((int)PowerGroup.SystemPower).ToString(),
                        PowerStatus = 1,
                        CreateTime = DateTime.Now,
                        ModifyTime = DateTime.Now
                    };
                    var res = _powerService.AddPower(power);
                    powerMenuList.Add(new Basic_PowerMenu()
                    {
                        MenuId = item.Id,
                        PowerId = res.Id,
                        CreateTime = DateTime.Now,
                        ModifyTime = DateTime.Now,
                        MappingStatus = true
                    });

                }

                _powerMenuService.AddPowerMenuRang(powerMenuList);
            }
            catch (ArgumentNullException e)
            {

                return e.Message;
            }
            return string.Empty;
        }



        public ActionResult MenuList(int id)
        {
            var power = _powerService.GetPowerById(id);
            var menuList = _menuService.GetMenus();
            ViewBag.Group = EnumHelper.GetItemValueList<MenuType>();
            ViewBag.Menus = menuList;
            return View(power);
        }

        [HttpPost]
        public ActionResult MenuList(int id, List<int> MenuIds)
        {
            _powerMenuService.DeleteByPowerId(id);
            if (MenuIds != null)
            {
                var powerMenuList = new List<Basic_PowerMenu>();
                foreach (var item in MenuIds)
                {
                    powerMenuList.Add(new Basic_PowerMenu()
                    {
                        PowerId = id,
                        MenuId = item,
                        MappingStatus = true,
                        CreateTime = DateTime.Now,
                        ModifyTime = DateTime.Now
                    });
                }
                _powerMenuService.AddPowerMenuRang(powerMenuList);
            }

            return this.RefreshParent();
        }
    }
}
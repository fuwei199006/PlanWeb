using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Framework.Contract;

using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using Plain.BLL.MenuService;
using Plain.Dto;
using Framework.Utility;

namespace Plain.UI.Areas.Auth.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;

        }
        // GET: Auth/Menu
        public ActionResult Index(MenuRequest menuRequest)
        {
            PagedList<Basic_MenuDto> menuList =
               _menuService.GetMenuDtos(menuRequest.MenuName, menuRequest.PageIndex, menuRequest.PageSize);

            return View(menuList);
        }


        public ActionResult Edit(int id)
        {
            var menu = _menuService.GetMenuById(id);

            SetDropEnumViewData<MenuType>(WebKeys.MenuTypeDrop);
            SetDropEnumViewData<StatusType>(WebKeys.StatusTypeDrop);
            ViewData["MenuListDrop"] = _menuService.GetMenus().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.MenuName
            }).Concat<SelectListItem>(new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "0",
                    Text = "无"
                }
            });


            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            var menu = _menuService.GetMenuById(id);
            this.TryUpdateModel<Basic_Menu>(menu);

            menu.ModifyTime = DateTime.Now;
            _menuService.UpdateMenu(menu);
            return this.RefreshParent();
        }


        public ActionResult Create()
        {

            SetDropEnumViewData<MenuType>(WebKeys.MenuTypeDrop);
            SetDropEnumViewData<StatusType>(WebKeys.StatusTypeDrop);
            ViewData["MenuListDrop"] = _menuService.GetMenus().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.MenuName
            }).Concat<SelectListItem>(new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "0",
                    Text = "无"
                }
            });
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var menu = new Basic_Menu();
            this.TryUpdateModel(menu);
            menu.CreateTime = DateTime.Now;
            menu.ModifyTime = DateTime.Now;
            _menuService.AddMenu(menu);
            return this.RefreshParent();
        }

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this._menuService.DeleteMenus(ids);
            return RedirectToAction("Index");
        }
    }
}
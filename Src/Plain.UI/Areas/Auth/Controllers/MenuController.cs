using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Contract;
using Framework.Extention;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using Plain.Web;
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
               _menuService.GetMenuDtos(menuRequest.MenuName,menuRequest.PageIndex, menuRequest.PageSize);

            return View(menuList);
        }


        public ActionResult Edit(int id)
        {
            var menu = _menuService.GetMenuById(id);
            ViewData["MenuTypes"] = EnumHelper.GetItemList<MenuType>().Select(r => new SelectListItem()
            {
                Value = r.Key.ToString(),
                Text = r.Value.ToString()
            });
            ViewData["StatusTypes"] = EnumHelper.GetItemValueList<StatusType>().Select(r => new SelectListItem()
            {
                Value = r.Key == 0 ? "true" : "false",
                Text = r.Value.ToString()
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

            ViewData["MenuTypes"] = EnumHelper.GetItemList<MenuType>().Select(r => new SelectListItem()
            {
                Value = r.Key.ToString(),
                Text = r.Value.ToString()
            });
            ViewData["StatusTypes"] = EnumHelper.GetItemValueList<StatusType>().Select(r => new SelectListItem()
            {
                Value = r.Key==0?"true":"false",
                Text = r.Value.ToString()
            });
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var menu=new Basic_Menu();
            this.TryUpdateModel(menu);
            menu.CreateTime=DateTime.Now;
            menu.ModifyTime=DateTime.Now;
            _menuService.AddMenu(menu);
            return this.RefreshParent();
        }
    }
}
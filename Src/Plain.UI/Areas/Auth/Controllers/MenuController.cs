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
               _menuService.GetMenuDtos().ToPagedList(menuRequest.PageIndex,menuRequest.PageSize,AdminMenuCache.Current.Menus.Count);

            return View(menuList);
        }

        public ActionResult Edit(int id)
        {
            
            return View();
        }
    }
}
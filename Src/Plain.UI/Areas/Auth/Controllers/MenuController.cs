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

namespace Plain.UI.Areas.Auth.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Auth/Menu
        public ActionResult Index(MenuRequest menuRequest)
        {
            PagedList<Basic_Menu> menuList =
                AdminCacheContext.Current.MenuItems.Menus.ToList().ToPagedList(menuRequest.PageIndex,menuRequest.PageSize,AdminMenuCache.Current.Menus.Count);

            return View(menuList);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
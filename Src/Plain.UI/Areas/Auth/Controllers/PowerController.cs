using Framework.Utility;
using Plain.BLL.PowerService;
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
    public class PowerController : BaseController
    {

        private readonly IPowerService _powerService;

        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Utility.Extention;
using HR.CustomDto;
using Newtonsoft.Json;
using Plain.UI.Controllers;

namespace Plain.UI.Areas.HR.Controllers
{
    public class SalaryController : BaseController
    {

        private const int Year = 3;
        // GET: HR/Salary
        public ActionResult Index()
        {
            var yearArr = new string[Year];
            var monthArr = new string[12];
            var nowYear = DateTime.Now.AddYears(-2).Year;

            for (int i = 0; i < Year; i++)
            {
                yearArr[i] = (nowYear + i).ToString();
            }
            for (int i = 0; i < 12; i++)
            {
                monthArr[i] = (i+1) > 9 ? (i+1).ToString() : "0" + (i+1);
            }

            ViewBag.Option = JsonConvert.SerializeObject(new
            {
                yearArr,
                monthArr,
                currentYear=DateTime.Now.Year,
                currentMonth=DateTime.Now.Month+1
            });
            return View();
        }

        public JsonResult GetSalary(string paras)
        {
            var salaryPara = paras.ToEntity<SalaryPara>();
            if (null != salaryPara)
            {
                return new JsonResult();
            }
            return new JsonResult();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Utility.Extention;
using HR.BLL.SalayService;
using HR.CustomDto;
using Newtonsoft.Json;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;

namespace Plain.UI.Areas.HR.Controllers
{
    public class SalaryController : BaseController
    {
        private readonly ISalayService _salaryService;

        public SalaryController(ISalayService salaryService)
        {
            _salaryService = salaryService;
        }

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
                monthArr[i] = (i + 1) > 9 ? (i + 1).ToString() : "0" + (i + 1);
            }

            ViewBag.Option = JsonConvert.SerializeObject(new
            {
                yearArr,
                monthArr,
                currentYear = DateTime.Now.Year,
                currentMonth = DateTime.Now.Month + 1
            });
            return View();
        }

        public JsonResult GetSalary(string paras)
        {
            var salaryPara = paras.ToEntity<SalaryPara>();
            if (null != salaryPara)
            {
                var res = _salaryService.GetSalaryByOption(salaryPara);
                if (res == null || res.Count == 0)
                {
                    return new JsonResult();
                }
                var maxLength = res.GroupBy(r => r.SalaryModule).Max(x => x.Count());
                var fixdTime = res.Where(r => r.SalaryModule == "A").ToList();
                var specialItems = res.Where(r => r.SalaryModule == "S").ToList();
                var returnProject = res.Where(r => r.SalaryModule == "C").ToList();
                var otherItem = res.Where(r => r.SalaryModule == "B").ToList();
                var referenceItem = res.Where(r => r.SalaryModule == "D").ToList();
                var realEntity = res.FirstOrDefault(r => r.SalaryModule == "T") ?? new Salary()
                {
                    SalaryDesc = "实际工资",
                    SalaryAccout = 0.0M
                };
                AddEmptyElement(fixdTime, maxLength);
                AddEmptyElement(specialItems, maxLength);
                AddEmptyElement(returnProject, maxLength);
                AddEmptyElement(otherItem, maxLength);
                AddEmptyElement(referenceItem, maxLength);
                return Json(new
                {
                    fixdTime = fixdTime,
                    specialItems = specialItems,
                    returnProject = returnProject,
                    otherItem = otherItem,
                    referenceItem = referenceItem,
                    realEntity=realEntity

                });
            }
            return new JsonResult();
        }


        private void AddEmptyElement(List<Salary> list, int maxLength)
        {
            var rang = maxLength - list.Count;
            for (int i = 0; i < rang; i++)
            {
                list.Add(new Salary());
            }
        }
    }
}
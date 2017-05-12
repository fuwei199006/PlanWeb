using System.Collections.Generic;
using System.Linq;
using HR.CustomDto;
using Plain.BLL;
using Plain.BLL.ArticleService;
using Plain.Model.Models.Model;

namespace HR.BLL.SalayService
{
    public class SalayService : BaseService<Salary>, ISalayService
    {
        public List<Salary> GetSalaryByOption(SalaryPara paras)
        {
            return this.LoadEntities(r => r.SalaryStaff == paras.usercode && r.SalaryDate == paras.date).ToList();
        }
    }
}

using System.Collections.Generic;
using HR.CustomDto;
using Plain.BLL;
using Plain.Model.Models.Model;

namespace HR.BLL.SalayService
{
    public interface ISalayService:IBaseService<Salary>
    {
        List<Salary> GetSalaryByOption(SalaryPara paras);
    }
}
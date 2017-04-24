using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models.Model;

namespace HR.CustomDto
{
    public class SalayDto
    {
        public SalayDto(string userName,string userCode,string dept,string location,List<Salary> salaries )
        {
            this.UserCode = userCode;
            UserName = userName;
            Dept = dept;
            Location = location;
            FixedItems = salaries.Where(r => r.SalaryModule == "A").ToList();
            SpecialItems = salaries.Where(r => r.SalaryModule == "S").ToList();
            DepriveItems = salaries.Where(r => r.SalaryModule == "C").ToList();
            RefItems = salaries.Where(r => r.SalaryModule == "D").ToList();
            OtherItems = salaries.Where(r => r.SalaryModule == "B").ToList();
        }
       public string UserName { get; set; }
       public string UserCode { get; set; }
       public string Dept { get; set; }
       public string Location { get; set; }
        /// <summary>
        /// 固定项目 
        /// </summary>
       public List<Salary> FixedItems { get; set; }
        /// <summary>
        /// 特殊项目
        /// </summary>
       public List<Salary> SpecialItems { get; set; }
        /// <summary>
        /// 扣发项目
        /// </summary>
       public List<Salary> DepriveItems { get; set; }
        /// <summary>
        /// 参考项目
        /// </summary>
       public List<Salary> RefItems { get; set; }
        /// <summary>
        /// 其它项目
        /// </summary>
       public List<Salary> OtherItems { get; set; }
  
    }


    public class SalaryPara
    {
        public  string usercode { get; set; }
        public  string date { get; set; }
        public  string isSentMail { get; set; }
    }

 
}

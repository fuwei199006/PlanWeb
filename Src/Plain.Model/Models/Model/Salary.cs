using System;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public class Salary : ModelBase
    {

        public string SalaryDate { get; set; }
        public string SalaryKey { get; set; }
        public string SalaryDesc { get; set; }
        public decimal? SalaryAccout { get; set; }
        public string SalaryStaff { get; set; }

        public  string SalaryModule { get; set; }


        public DateTime ModifyTime { get; set; }
    }
}
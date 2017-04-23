   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Salary:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string SalaryDate {get;set;}
	 	   public string SalaryKey {get;set;}
	 	   public string SalaryDesc {get;set;}
	 	   public decimal? SalaryAccout {get;set;}
	 	   public string SalaryStaff {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_Power:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string PoweName {get;set;}
	 	   public int? PowerStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	 	   public string PowerGroup {get;set;}
	   }
}


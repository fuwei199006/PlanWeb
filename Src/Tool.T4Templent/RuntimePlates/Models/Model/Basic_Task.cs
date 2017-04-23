   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_Task:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string TaskName {get;set;}
	 	   public DateTime StarTime {get;set;}
	 	   public DateTime EndTime {get;set;}
	 	   public bool? TaskStatus {get;set;}
	 	   public DateTime? ExecTime {get;set;}
	 	   public DateTime? ExecEndTime {get;set;}
	 	   public string ReturnMsg {get;set;}
	   }
}


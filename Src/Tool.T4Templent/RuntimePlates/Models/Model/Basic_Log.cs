   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_Log:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string Level {get;set;}
	 	   public string Logger {get;set;}
	 	   public string Host {get;set;}
	 	   public DateTime? Date {get;set;}
	 	   public string Thread {get;set;}
	 	   public string Message {get;set;}
	 	   public string Exception {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Log4net:ModelBase
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


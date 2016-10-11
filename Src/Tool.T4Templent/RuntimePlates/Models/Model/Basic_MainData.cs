   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_MainData:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string MainKey {get;set;}
	 	   public string MainCode {get;set;}
	 	   public string MainData {get;set;}
	 	   public bool MainStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


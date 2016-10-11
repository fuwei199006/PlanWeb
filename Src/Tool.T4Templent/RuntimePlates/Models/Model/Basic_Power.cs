   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Power:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string PoweName {get;set;}
	 	   public bool? PowerStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Config:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string ConfigKey {get;set;}
	 	   public string ConfigValue {get;set;}
	 	   public bool? CongfigStatus {get;set;}
	 	   public string ConfigCategory {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


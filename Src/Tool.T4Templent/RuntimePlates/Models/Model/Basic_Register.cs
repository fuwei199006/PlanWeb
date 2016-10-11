   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Register:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string RegisterName {get;set;}
	 	   public string RegisterPassword {get;set;}
	 	   public string RegisterEmail {get;set;}
	 	   public string RegisterPhone {get;set;}
	 	   public DateTime? RegisterTime {get;set;}
	 	   public DateTime? Expiretime {get;set;}
	 	   public bool? RegisterStatus {get;set;}
	 	   public string RegisterDevice {get;set;}
	 	   public string RetisterIp {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public Guid? RegisterToken {get;set;}
	   }
}


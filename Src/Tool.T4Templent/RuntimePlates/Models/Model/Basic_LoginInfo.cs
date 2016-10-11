   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_LoginInfo:ModelBase
    {
       	   public int Id {get;set;}
	 	   public int LoginUserId {get;set;}
	 	   public string LoginName {get;set;}
	 	   public DateTime? LoginTime {get;set;}
	 	   public int LoginStatus {get;set;}
	 	   public int LoginType {get;set;}
	 	   public DateTime? ExpireTime {get;set;}
	 	   public string LoginIp {get;set;}
	 	   public string LoginHeader {get;set;}
	 	   public bool? IsDelete {get;set;}
	 	   public DateTime? LastUpdateTime {get;set;}
	 	   public Guid? LoginToken {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	   }
}


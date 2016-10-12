   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_UserInfo:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string LoginName {get;set;}
	 	   public string NickName {get;set;}
	 	   public string UserEmail {get;set;}
	 	   public string UserPwd {get;set;}
	 	   public string RealName {get;set;}
	 	   public string RegisterDevice {get;set;}
	 	   public string RegisterIp {get;set;}
	 	   public string RegiserHeader {get;set;}
	 	   public DateTime? RegisterTime {get;set;}
	 	   public int? UserStaus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


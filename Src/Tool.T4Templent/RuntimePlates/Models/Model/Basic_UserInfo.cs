   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_UserInfo:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string LoginName {get;set;}
	 	   public string NickName {get;set;}
	 	   public string UserEmail {get;set;}
	 	   public string UserPwd {get;set;}
	 	   public string RealName {get;set;}
	 	   public int? UserStaus {get;set;}
	 	   public string MobilePhone {get;set;}
	 	   public DateTime? BirthDay {get;set;}
	 	   public string QQ {get;set;}
	 	   public string Weixin {get;set;}
	 	   public string Addr {get;set;}
	 	   public string OtherInfo {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	 	   public int? Sex {get;set;}
	   }
}


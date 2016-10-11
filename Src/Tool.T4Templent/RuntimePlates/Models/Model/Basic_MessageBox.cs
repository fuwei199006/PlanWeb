   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_MessageBox:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string Title {get;set;}
	 	   public string Content {get;set;}
	 	   public int? MessageStatus {get;set;}
	 	   public int ToUserId {get;set;}
	 	   public string ToUserName {get;set;}
	 	   public int FromUserId {get;set;}
	 	   public string FromUserName {get;set;}
	 	   public DateTime SentTime {get;set;}
	   }
}


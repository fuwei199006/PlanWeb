   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Commit:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string Content {get;set;}
	 	   public string CommitUserName {get;set;}
	 	   public int CommitUserId {get;set;}
	 	   public int? CommitType {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


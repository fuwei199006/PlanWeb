   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Menu:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string MenuName {get;set;}
	 	   public string MenuUrl {get;set;}
	 	   public string MenuType {get;set;}
	 	   public int? MenuSort {get;set;}
	 	   public int? MenuParentId {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	 	   public int? MenuStatus {get;set;}
	 	   public string MenuIcon {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Role:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string RoleName {get;set;}
	 	   public bool? RoleStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_Role:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string RoleName {get;set;}
	 	   public int RoleStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	 	   public string RoleGroup {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_UserRole:ModelBase
    {
       	   public int Id {get;set;}
	 	   public int UserId {get;set;}
	 	   public int RoleId {get;set;}
	 	   public bool? MappingStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


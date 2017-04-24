   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_PowerMenu:ModelBase
    {
       	   public int Id {get;set;}
	 	   public int PowerId {get;set;}
	 	   public int MenuId {get;set;}
	 	   public bool MappingStatus {get;set;}
	 	   public DateTime CreateTime {get;set;}
	 	   public DateTime ModifyTime {get;set;}
	   }
}


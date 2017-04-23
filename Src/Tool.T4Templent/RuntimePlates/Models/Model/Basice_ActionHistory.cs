   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basice_ActionHistory:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string ActionType {get;set;}
	 	   public string ActionName {get;set;}
	 	   public string ActionExcutorId {get;set;}
	 	   public string ActionExcutorName {get;set;}
	 	   public string ActionExcutorRole {get;set;}
	 	   public string ActionBackPack {get;set;}
	 	   public string ActionResult {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


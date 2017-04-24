using System;
using Framework.Contract;

namespace   Plain.Model.Models.Model
{
    public partial class Basic_Dictionary:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string FieldName {get;set;}
	 	   public string FieldRemark {get;set;}
	 	   public bool? DicStatus {get;set;}
	 	   public string FieldModule {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Dictionary:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string FieldName {get;set;}
	 	   public string FieldRemark {get;set;}
	 	   public bool? DicStatus {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}


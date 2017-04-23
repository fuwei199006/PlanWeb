   using System;
using Framework.Contract;
namespace   Plain.Model.Models.Model.Models.Model
{
    public partial class Basic_Draft:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string Title {get;set;}
	 	   public string Author {get;set;}
	 	   public string Category {get;set;}
	 	   public string Content {get;set;}
	 	   public string Source {get;set;}
	 	   public string KeyWord {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTIme {get;set;}
	   }
}


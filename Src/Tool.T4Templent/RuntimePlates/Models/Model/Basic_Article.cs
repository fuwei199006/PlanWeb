   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_Article:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string Title {get;set;}
	 	   public string SubTitle {get;set;}
	 	   public string Author {get;set;}
	 	   public string Category {get;set;}
	 	   public string Content {get;set;}
	 	   public string Source {get;set;}
	 	   public string SourceUrl {get;set;}
	 	   public int Sort {get;set;}
	 	   public string KeyWord {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTIme {get;set;}
	 	   public int? ArticleStatus {get;set;}
	   }
}


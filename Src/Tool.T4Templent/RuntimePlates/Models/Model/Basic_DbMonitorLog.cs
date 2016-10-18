﻿   using System;
using Framework.Contract;
namespace  Tool.T4Templent.RuntimePlates.Models.Model
{
    public partial class Basic_DbMonitorLog:ModelBase
    {
       	   public int Id {get;set;}
	 	   public string TableName {get;set;}
	 	   public string DbName {get;set;}
	 	   public string EventType {get;set;}
	 	   public string NewValues {get;set;}
	 	   public string UserName {get;set;}
	 	   public string ModuleName {get;set;}
	 	   public DateTime? CreateTime {get;set;}
	 	   public DateTime? ModifyTime {get;set;}
	   }
}

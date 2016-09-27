using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.Config;
using Framework.Extention;

namespace Tool.T4Templent.ServiceAndDto
{
    public class ModelProvider
    {
        public static MssqlDbHelper SqlDbHelper = null;

        static ModelProvider()
        {
            SqlDbHelper.conStr = LocalCachedConfigContext.Current.DaoConfig.BussinessDaoConfig;

        }
        public static List<string> GetTable()
        {
            var sql = @"SELECT Name FROM  PlanDB..SysObjects Where XType='U'  ";
            var dbTable = SqlDbHelper.ExecReturnDataSet(sql).Tables[0];
            return dbTable.Select().Select(x => x["Name"].ToString()).ToList();
        }


        public static List<Filed> GetFiledByTable(string tableName)
        {
            var sql = @"    SELECT    col.name AS Name ,
                                    type.name AS Type,
			                        col.length AS Length,
			                        col.isnullable AS IsNullAble
                          FROM      sys.syscolumns col
                                    JOIN sys.systypes type ON type.xtype = col.xtype
                          WHERE     id = OBJECT_ID('Basic_LoginInfo')
                          ORDER BY  col.colorder";
            var dbFiled = SqlDbHelper.ExecReturnDataSet(sql).Tables[0];
            return dbFiled.ToList<Filed>().ToList();

        }

      
    }


    public class Filed
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }

        public int IsNullable { get; set; }
    }
}
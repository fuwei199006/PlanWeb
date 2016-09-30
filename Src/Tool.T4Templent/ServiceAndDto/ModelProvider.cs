using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Core.Config;
using Core.Encrypt;
using Framework.Extention;

namespace Tool.T4Templent.ServiceAndDto
{
    public class ModelProvider
    {
        public static MssqlDbHelper SqlDbHelper = null;

        static ModelProvider()
        {
            SqlDbHelper = new MssqlDbHelper();
            SqlDbHelper.conStr = "server=.;database=Account;user id=sa;password=Abc12345";// DESEncrypt.Decode(LocalCachedConfigContext.Current.DaoConfig.BussinessDaoConfig);


        }

        public static string DbName
        {
            get { return SqlDbHelper.GetDbName(); }
        }
        public static List<string> GetTable()
        {
            var sql = string.Format(@"SELECT Name FROM  {0}..SysObjects Where XType='U'  ", DbName);
            var dbTable = SqlDbHelper.ExecReturnDataSet(sql).Tables[0];
            return dbTable.Select().Select(x => x["Name"].ToString()).ToList();
        }


        public static List<Filed> GetFiledByTable(string tableName)
        {
            var sql = string.Format(@"    SELECT    col.name AS Name ,
                                    type.name AS SqlType,
			                        col.length AS Length,
			                        col.isnullable AS IsNullAble
                          FROM      sys.syscolumns col
                                    JOIN sys.systypes type ON type.xusertype = col.xtype
                          WHERE     id = OBJECT_ID('{0}')
                          ORDER BY  col.colorder", tableName);
            var dbFiled = SqlDbHelper.ExecReturnDataSet(sql).Tables[0];
            var primaryKey = string.Empty;
            var primaryTable = SqlDbHelper.ExecReturnDataSet(string.Format("EXEC sp_pkeys @table_name='{0}'", tableName)).Tables[0];
            if (primaryTable != null && primaryTable.Rows.Count > 0)
            {
                primaryKey = primaryTable.Rows[0]["COLUMN_NAME"].ToString();
            }
            var filedList = dbFiled.ToList<Filed>().ToList();
            if (!string.IsNullOrEmpty(primaryKey))
            {
                filedList.Where(r => r.Name == primaryKey).First().IsPrimaryKey = true;
            }
            return filedList;

        }

        /// <summary>
        /// 检测生成的字段是否合法，是否有关键字，是否是数字开头，如果则跳过
        ///
        /// </summary>
        /// <param name="filedName"></param>
        /// <returns></returns>
        public string CheckFiled(string filedName)
        {
            return filedName;
        }




    }


    public class Filed
    {
        public string Name { get; set; }

        public string Type
        {
            get { return GetCsharpMapping(SqlType); }

        }

        public string SqlType { get; set; }

        public int Length { get; set; }

        public int IsNullable { get; set; }

        public bool IsPrimaryKey { get; set; }
        private string GetCsharpMapping(string dataType)
        {
            string retType = "";
            if (dataType.Equals("text") || dataType.Equals("varchar") || dataType.Equals("char") || dataType.Equals("nvarchar") || dataType.Equals("nchar"))
                return "string";
            if (dataType.Equals("int"))
                return "int";
            if (dataType.Equals("bigint"))
                return "Int64";
            if (dataType.Equals("smallint"))
                return "Int16";
            if (dataType.Equals("tinyint"))
                return "byte";
            if (dataType.Equals("bigint"))
                return "long";
            if (dataType.Equals("bit"))
                return "bool";
            if (dataType.Equals("money") || dataType.Equals("smallmoney") || dataType.Equals("numeric")|| dataType.Equals("decimal"))
                return "decimal";
            if (dataType.Equals("datetime") || dataType.Equals("smalldatetime") || dataType.Equals("timestamp") || dataType.Equals("date"))
                return "DateTime";
            if (dataType.Equals("real"))
                return "Single";
            if (dataType.Equals("float"))
                return "double";
            if (dataType.Equals("image") || dataType.Equals("binary") || dataType.Equals("varbinary"))
                return "byte[]";
            if (dataType.Equals("uniqueidentifier"))
                return "Guid";
            return retType;
        }
    }
}
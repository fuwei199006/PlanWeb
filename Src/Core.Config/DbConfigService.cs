using System;
using System.IO;
using Core.Encrypt;
using Core.Exception;
 

namespace Core.Config
{
    public class DbConfigService : IConfigService, IDbConfigService
    {
        public string GetConfig(string key)
        {
            var category = key.Split('-')[0];
            var configKey = key.Split('-')[1];
            var connstr = GetConnectString("DaoConfig");
            var dbHelper = new MssqlDbHelper()
            {
                conStr = connstr
            };

            var db = dbHelper.ExecReturnDataSet(string.Format(@"
                    IF NOT EXISTS ( SELECT  *
                            FROM    PlanDB..sysobjects
                            WHERE   name = 'Basic_Config' )
                    BEGIN
                    CREATE TABLE Basic_Config
                        (
                            Id INT PRIMARY KEY
                                    IDENTITY ,
                            ConfigKey NVARCHAR(20) ,
                            ConfigValue NVARCHAR(100) ,
                            CongfigStatus BIT DEFAULT 1 ,
                            ConfigCategory NVARCHAR(50) ,
                            CreateTime DATETIME ,
                            ModifyTime DATETIME
                        );
      
                SELECT * FROM  dbo.Basic_Config WHERE ConfigKey='{0}' AND ConfigCategory='{1}' AND CongfigStatus=1
                    END;
                ELSE
                    SELECT * FROM  dbo.Basic_Config WHERE ConfigKey='{0}' AND ConfigCategory='{1}' AND CongfigStatus=1", configKey, category)).Tables[0];
            if (db.Rows.Count > 0)
            {
                return db.Rows[0]["ConfigValue"].ToString();
            }
            return String.Empty;
        }

        public void SaveConfig(string key, string value)
        {
            var category = key.Split('-')[0];
            var configKey = key.Split('-')[1];
            var connstr = GetConnectString("DaoConfig");
            var dbHelper = new MssqlDbHelper()
            {
                conStr = connstr
            };
            var existValue = GetConfig(key);
            dbHelper.ExceSql(existValue == "NaN"
                ? string.Format(
                    @"INSERT  dbo.Basic_Config ( ConfigKey , ConfigValue , CongfigStatus , ConfigCategory , CreateTime , ModifyTime ) VALUES  ( N'{0}' , N'{1}' , 1 , N'{2}' , GETDATE() , GETDATE() )",
                    configKey, value, category)
                : string.Format(
                    @"UPDATE dbo.Basic_Config SET ConfigValue='{0}' ,ModifyTime=GETDATE() WHERE ConfigKey='{1}' AND ConfigCategory='{2}'",
                    value, configKey, category));
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="key"></param>
        public void DeleteConfig(string key)
        {
            var category = key.Split('-')[0];
            var configKey = key.Split('-')[1];
            var connstr = GetConnectString("DaoConfig");
            var dbHelper = new MssqlDbHelper()
            {
                conStr = connstr
            };

            dbHelper.ExceSql(string.Format(@"UPDATE dbo.Basic_Config SET CongfigStatus=0,ModifyTime=GETDATE() WHERE ConfigKey='{0}' AND ConfigCategory='{1}'", configKey, category));
        }

        public string GetConnectString(string key)
        {
            var configFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            if (!Directory.Exists(configFolder))
            {
                ;
                Directory.CreateDirectory(configFolder);
            }
            var configPath = configFolder + "//" + string.Format("{0}.config", key);
            if (!File.Exists(configPath))
            {
                throw new ConfigNotExistException("没有找到配置文件！");
            }
            var content = File.ReadAllText(configPath);
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            return DESEncrypt.Decode(content);
        }


    }
}
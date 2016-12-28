using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Core.Config;
using Framework.Contract;
using Framework.DbDrive.EntityFramework;
using Newtonsoft.Json;

namespace Core.Log
{
    [Table("Basic_DbMonitorLog")]
    public class Basic_DbMonitorLog : ModelBase
    {
        public string ModuleId { get; set; }
        public string TableName { get; set; }
        public string DbName { get; set; }
        public string EventType { get; set; }
        public string NewValues { get; set; }
        public string UserName { get; set; }
        public string ModuleName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }

    public class LogDbContext : DbContextBase, IAuditable
    {
        public LogDbContext()
            : base(LocalCachedConfigContext.Current.DaoConfig.Log)
        {
            Database.SetInitializer<LogDbContext>(null); //???
        }

        public DbSet<Basic_DbMonitorLog> AuditLogs { get; set; }

        public void WriteLog(int modelId, string userName, string moduleName, string tableName, string eventType,
            ModelBase newValues, string dbName)
        {
            //AuditLogs.Add(new Basic_DbMonitorLog
            //{
            //    ModuleId = modelId.ToString(),
            //    DbName = dbName,
            //    ModuleName = moduleName,
            //    EventType = eventType,
            //    UserName = userName,
            //    TableName = tableName,
            //    CreateTime = DateTime.Now,
            //    ModifyTime = DateTime.Now,
            //    NewValues =
            //        JsonConvert.SerializeObject(newValues,
            //            new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore})
            //});

            //SaveChanges();
            //Dispose();
        }
    }
}
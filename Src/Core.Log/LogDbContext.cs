using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Core.Config;
using Framework.Contract;
using Framework.DbDrive.EntityFramework;
using Newtonsoft.Json;
using System;

namespace Core.Log
{
    [Table("Basice_ActionHistory")]
    public class AuditLog : ModelBase
    {
        public string ActionModule { get; set; }
        public string ActionType { get; set; }
        public string ActionName { get; set; }
        public string ActionExcutorId { get; set; }
        public string ActionExcutorName { get; set; }
        public string ActionExcutorRole { get; set; }
        public string ActionBackPack { get; set; }
        public string ActionResult { get; set; }
        public string ActionDesc { get; set; }
        public DateTime? ModifyTime { get; set; }
    }

    public class LogDbContext : DbContextBase, IAuditable
    {
        public LogDbContext()
            : base(LocalCachedConfigContext.Current.DaoConfig.Log)
        {
            Database.SetInitializer<LogDbContext>(null);//???
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public void WriteLog(int modelId, string userName, string moduleName, string tableName, string eventType, ModelBase newValues)
        {
            this.AuditLogs.Add(new AuditLog()
            {
                ActionModule=moduleName,
                ActionType = eventType,
                ActionExcutorName = userName,
                ActionName = moduleName,
                CreateTime = DateTime.Now,
                ModifyTime=DateTime.Now,
                ActionResult = JsonConvert.SerializeObject(newValues, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            });

            this.SaveChanges();
            this.Dispose();
        }
    }
}

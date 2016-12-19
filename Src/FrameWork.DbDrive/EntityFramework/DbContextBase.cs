using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Encrypt;
using Framework.Contract;
using Framework.Extention;
using Core.Config;

namespace Framework.DbDrive.EntityFramework
{
    public class DbContextBase : DbContext, IDataRepository, IDisposable
    {
        private static readonly object Lok = new object();
        public DbContextBase(string connectionString)
        {
            
            this.Database.Connection.ConnectionString = DESEncrypt.Decode(connectionString);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            //this.Database.Initialize(false);
        }
        public DbContextBase(string connectionString, IAuditable auditLogger)
            : this(connectionString)
        {
            this.AuditLogger = auditLogger;
        }

        public IAuditable AuditLogger { get; set; }
        public T Add<T>(T entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.Add(entity);
            this.SaveChanges();
            return entity;
        }

        public void AddRange<T>(IList<T> entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.AddRange(entity);
            this.SaveChanges();

        }

        public T Update<T>(T entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
            this.SaveChanges();

            return entity;
        }
        public void UpdateRang<T>(IList<T> entities) where T : ModelBase
        {
            var set = this.Set<T>();
            foreach (var entity in entities)
            {
                set.Attach(entity);
                this.Entry<T>(entity).State = EntityState.Modified;
            }
            this.SaveChanges();
        }
        public T Delete<T>(T entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Deleted;
            this.SaveChanges();
            return entity;
        }

        public void DeleteRange<T>(IList<T> entities) where T : ModelBase
        {
            var set = this.Set<T>();
            foreach (var entity in entities)
            {
                set.Attach(entity);
                this.Entry<T>(entity).State = EntityState.Deleted;
            }

            this.SaveChanges();

        }


        public T GetEntity<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions != null)
            {
                return this.Set<T>().Where(conditions).ToList().FirstOrDefault();
            }
            return default(T);
        }
        public T GetEntityWithNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions != null)
            {
                return this.Set<T>().Where(conditions).ToList().FirstOrDefault();
            }
            return default(T);
        }
        public IQueryable<T> LoadEntitiesNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions == null)
                return this.Set<T>().AsNoTracking();
            else
                return this.Set<T>().Where(conditions).AsNoTracking();
        }

        public IQueryable<T> LoadEntities<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions == null)
                return this.Set<T>();
            else
                return this.Set<T>().Where(conditions);
        }

        public PagedList<T> LoadEntitiesByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            var queryList = conditions == null ? this.Set<T>() : this.Set<T>().Where(conditions);

            return queryList.OrderBy(orderBy).ToPagedList(pageIndex, pageSize);

        }

        public override int SaveChanges()
        {
            this.WriteLog();
            return base.SaveChanges();
        }

        public DbRawSqlQuery<T> ExceSql<T>(string sql) where T : class
        {
            return this.Database.SqlQuery<T>(sql);
        }

        public DbRawSqlQuery<T> ExceSql<T>(string sql, SqlParameter[] parameters) where T : class
        {
            return this.Database.SqlQuery<T>(sql, parameters);
        }

        public PagedList<T> ExceSqlPagedList<T>(string sql, int pageSize, int pageIndex) where T : class
        {
            return this.Database.SqlQuery<T>(sql).AsQueryable().ToPagedList(pageSize, pageIndex);
        }


        //todo:添加存储过程的执行

        //dbLog
        internal void WriteLog()
        {
            if (this.AuditLogger == null)
                return;
#if !DEBUG
            if (!LocalCachedConfigContext.Current.SystemConfig.IsDbMonitor)
            {
                return;//是否打开数据的监控日志
            }
#endif 
            foreach (
                var dbEntry in
                    this.ChangeTracker.Entries<ModelBase>()
                        .Where(
                            p =>
                                p.State == EntityState.Added || p.State == EntityState.Deleted ||
                                p.State == EntityState.Modified))
            {



                Task.Factory.StartNew(() =>
                {

                    var tableArr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                    var tableName = tableArr != null ? tableArr.Name : dbEntry.Entity.GetType().Name;
                    var dbName = this.Database.Connection.Database;// 
                    var operaterName = "Anoymous";
                    var moduleName = dbEntry.Entity.GetType().FullName.Split('.').Skip(1).FirstOrDefault();
                    this.AuditLogger.WriteLog(dbEntry.Entity.Id, operaterName, moduleName, tableName,
                    dbEntry.State.ToString(), dbEntry.Entity, dbName);

                });
            }

        }

    }
}
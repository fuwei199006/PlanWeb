﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Core.Cache;
using Core.Config;
using Core.Encrypt;
using Framework.Contract;
using Framework.Extention;

namespace Framework.DbDrive.EntityFramework
{
    public class DbContextBase:DbContext,IDataRepository, IDisposable
    {
        private static readonly object Lok = new object();
        public DbContextBase(string connectionString)
        {
            this.Database.Connection.ConnectionString =DESEncrypt.Decode(connectionString);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
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

        public T Delete<T>(T entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Deleted;
            this.SaveChanges();
            return entity;
        }

     

        public T GetEntity<T>(Expression<Func<T, bool>> conditions=null)where T : ModelBase
        {
            if (conditions != null)
            {
                return this.Set<T>().Where(conditions).FirstOrDefault();
            }
            return default(T);
        }
        public T GetEntityWithNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions != null)
            {
                return this.Set<T>().Where(conditions).AsNoTracking().FirstOrDefault();
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

            return queryList.OrderByDescending(orderBy).ToPagedList(pageIndex, pageSize);

        }

        public override int SaveChanges()
        {
            this.WriteLog();
            return base.SaveChanges();
        }


        //dbLog
        internal void WriteLog()
        {
            if(this.AuditLogger==null)
                return;
            if (!LocalCachedConfigContext.Current.SystemConfig.IsMonitor)
            {
                return;//是否打开数据的监控日志
            } 
            foreach (
                var dbEntry in
                    this.ChangeTracker.Entries<ModelBase>()
                        .Where(
                            p =>
                                p.State == EntityState.Added || p.State == EntityState.Deleted ||
                                p.State == EntityState.Modified))
            {

                //var auditableAttr =
                //    dbEntry.Entity.GetType().GetCustomAttributes(typeof (AuditableAttribute), false).SingleOrDefault()
                //        as AuditableAttribute;
                //if(auditableAttr==null)continue;
                var operaterName = WcfContext.Current.Operater.Name;

                Task.Factory.StartNew(() =>
                {
                    var tableArr =
                        dbEntry.Entity.GetType().GetCustomAttributes(typeof (TableAttribute),false).SingleOrDefault() as TableAttribute;
                    var tableName = tableArr != null ? tableArr.Name : dbEntry.Entity.GetType().Name;
                    var dbName = this.Database.Connection.Database;//
                    var moduleName = dbEntry.Entity.GetType().FullName.Split('.').Skip(1).FirstOrDefault();
                    this.AuditLogger.WriteLog(dbEntry.Entity.Id, operaterName, moduleName, tableName,
                        dbEntry.State.ToString(), dbEntry.Entity, dbName);
                });
            }
             
        }
 
    }
}
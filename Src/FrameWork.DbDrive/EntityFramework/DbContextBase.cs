using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.Config;
using EntityFramework.Extensions;
using Framework.Contract;
using Framework.Extention;

namespace Framework.DbDrive.EntityFramework
{
    public class DbContextBase:DbContext,IDataRepository, IDisposable
    {
        public DbContextBase(string connectionString)
        {
            this.Database.Connection.ConnectionString = LocalCachedConfigContext.Current.DaoConfig.BussinessDaoConfig;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
      
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

        public T Find<T>(params object[] keyValues) where T : ModelBase
        {
           return this.Set<T>().Find(keyValues);
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions == null)
                return this.Set<T>().ToList();
            else
                return this.Set<T>().Where(conditions).ToList();
        }

        public PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            var queryList = conditions == null ? this.Set<T>() : this.Set<T>().Where(conditions) as IQueryable<T>;

            return queryList.OrderByDescending(orderBy).ToPagedList(pageIndex, pageSize);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
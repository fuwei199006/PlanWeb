using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Core.Config;
using Framework.Contract;

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
        public T Inser<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Delete<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Finde<T>(params object[] keyValues) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            throw new NotImplementedException();
        }
    }
}
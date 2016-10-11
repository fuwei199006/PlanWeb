using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using Framework.Contract;
using System.Linq;

namespace Framework.DbDrive.EntityFramework
{
    public interface IDataRepository
    {
        T Add<T>(T entity) where T : ModelBase;
        void AddRange<T>(IList<T> entity) where T : ModelBase;
        T Update<T>(T entity) where T : ModelBase;
        T Delete<T>(T entity) where T : ModelBase;
        T GetEntity<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;
        T GetEntityWithNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;

        IQueryable<T>  LoadEntitiesNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;
        IQueryable<T> LoadEntities<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;
        PagedList<T> LoadEntitiesByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase;
    }
}
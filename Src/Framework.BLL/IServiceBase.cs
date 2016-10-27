using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Contract;
using Framework.DAL;
using System.Linq;
namespace Framework.BLL
{
    public interface IServiceBase<T> where T : ModelBase
    {

        #region 基础的代码封装

        T Add(T entity);

        void AddRange(IList<T> entities);


        T Update(T entity);


        T Delete(T entity);


        T GetEntity(Expression<Func<T, bool>> conditions);

        T GetEntityWithNoTracking(Expression<Func<T, bool>> conditions);


        IQueryable<T> LoadEntitiesNoTracking(Expression<Func<T, bool>> conditions = null);

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> conditions = null);


        PagedList<T> LoadEntitiesByPage<S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex);

        #endregion

        #region  扩展方法

        T GetEntityById(int id);

        T GetEntityByIdNoTracking(int id);

        IQueryable<T> GetEntities(IList<int> ids);

        IQueryable<T> GetEntitiesNoTracking(IList<int> ids);

        void DeleteEntities(IList<int> ids);


        #endregion




    }
}
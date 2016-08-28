using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Contract;

namespace Framework.BLL
{
    public interface IServiceBase<T>
    {

        #region 基础的代码封装

          T Add(T entity);

          void AddRange(IList<T> entities);


        T Update(T entity);


        T Delete(T entity);



        T Find<T>(params object[] keyValues) where T : ModelBase;

        T Get<T>(Expression<Func<T, bool>> conditions) where T : ModelBase;

        T GetNoTracking<T>(Expression<Func<T, bool>> conditions) where T : ModelBase;

        List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;

        List<T> FindAllNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase;

        PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy,
            int pageSize, int pageIndex) where T : ModelBase;
        
        #endregion

        #region  扩展方法

        T GetById(int id);

        T GetByIdNoTracking(int id);

        List<T> GetList(Expression<Func<T, bool>> conditions);

        List<T> GetListNoTracking(Expression<Func<T, bool>> conditions);




        #endregion
    }
}
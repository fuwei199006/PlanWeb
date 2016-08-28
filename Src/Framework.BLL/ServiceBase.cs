using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Contract;
using Framework.DAL;

namespace Framework.BLL
{
    public abstract class ServiceBase<T>:IServiceBase<T> where T : ModelBase
    {
        public ResposityBase<T> CurrentResposity { get;set; }
        public abstract void SetCurrentResposity();

        #region 基础的代码封装
        public virtual T Add(T entity)
        {
            return this.CurrentResposity.Add(entity);
        }
        public virtual void AddRange(IList<T> entities)
        {
            this.CurrentResposity.AddRange(entities);
        }

        public virtual T Update(T entity)
        {
            return this.CurrentResposity.Update(entity);
        }

        public virtual T Delete(T entity)
        {
            return this.CurrentResposity.Delete(entity);
        }


        public virtual T Find<T>(params object[] keyValues) where T : ModelBase
        {
            return this.CurrentResposity.Find<T>(keyValues);
        }
        public virtual T Get<T>(Expression<Func<T, bool>> conditions) where T : ModelBase
        {
            return this.CurrentResposity.Get(conditions);
        }
        public virtual T GetNoTracking<T>(Expression<Func<T, bool>> conditions) where T : ModelBase
        {
            return this.CurrentResposity.GetNoTracking(conditions);
        }
        public virtual List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentResposity.FindAll(conditions);
        }
        public virtual List<T> FindAllNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentResposity.FindAllNoTracking(conditions);
        }
        public virtual PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            return this.CurrentResposity.FindAllByPage(conditions, orderBy, pageSize, pageIndex);
        }
        #endregion

        #region  扩展方法

        public virtual T GetById(int id)
        {
            return this.Get<T>(r => r.Id == id);
        }
        public virtual T GetByIdNoTracking(int id)
        {
            return this.GetNoTracking<T>(r => r.Id == id);
        }
        public virtual List<T> GetList(Expression<Func<T, bool>> conditions)
        {
            return this.FindAll(conditions);
        }
        public virtual List<T> GetListNoTracking(Expression<Func<T, bool>> conditions)
        {
            return this.FindAllNoTracking(conditions);
        }



        #endregion
    }
}
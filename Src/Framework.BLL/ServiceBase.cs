using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Contract;
using Framework.DAL;
using System.Linq;

namespace Framework.BLL
{
    public   class ServiceBase<T>:IServiceBase<T> where T : ModelBase
    {
        private  ResposityBase<T> CurrentResposity { get;set; }
         

        public ServiceBase(ResposityBase<T> resposityBase)
        {
            CurrentResposity = resposityBase;
        }

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

        public virtual T GetEntity(Expression<Func<T, bool>> conditions)  
        {
            return this.CurrentResposity.GetEntity(conditions);
        }
        public virtual T GetEntityWithNoTracking(Expression<Func<T, bool>> conditions) 
        {
            return this.CurrentResposity.GetEntityWithNoTracking(conditions);
        }
    
        public virtual IQueryable<T> LoadEntitiesNoTracking(Expression<Func<T, bool>> conditions = null)
        {
            return this.CurrentResposity.LoadEntitiesNoTracking(conditions);
        }

        public virtual IQueryable<T> LoadEntities(Expression<Func<T, bool>> conditions = null)
        {
            return this.CurrentResposity.LoadEntities(conditions);
        }

        public virtual PagedList<T> LoadEntitiesByPage<S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) 
        {
            return this.CurrentResposity.LoadEntitiesByPage(conditions, orderBy, pageSize, pageIndex);
        }
        #endregion

        #region  扩展方法

        public virtual T GetEntityById(int id)
        {
            return this.GetEntity(r => r.Id == id);
        }
        public virtual T GetEntityByIdNoTracking(int id)
        {
            return this.GetEntityWithNoTracking(r => r.Id == id);
        }

        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using Framework.Contract;
using Framework.DbDrive.EntityFramework;

namespace Framework.DAL
{
    public abstract class ResposityBase<T> where T : ModelBase
    {

        public virtual DbContextBase CurrentContextBase { get; set; }
        public abstract void SetCurrentDbContext();

        #region 基础的代码封装
        public virtual T Add(T entity)
        {
            return this.CurrentContextBase.Add(entity);
        }
        public virtual void AddRange(IList<T> entities)
        {
            this.CurrentContextBase.AddRange(entities);
        }

        public virtual T Update(T entity)
        {
            return this.CurrentContextBase.Update(entity);
        }

        public virtual T Delete(T entity)
        {
            return this.CurrentContextBase.Delete(entity);
        }


      
        public T GetEntity(Expression<Func<T, bool>> conditions) 
        {
            return this.CurrentContextBase.GetEntity(conditions);
        }
        public T GetEntityWithNoTracking(Expression<Func<T, bool>> conditions) 
        {
            return this.CurrentContextBase.GetEntityWithNoTracking(conditions);
        }
     
        public virtual IQueryable<T> LoadEntitiesNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentContextBase.LoadEntitiesNoTracking(conditions);
        }

        public virtual IQueryable<T> LoadEntities<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentContextBase.LoadEntities(conditions);
        }
        public virtual PagedList<T> LoadEntitiesByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            return this.CurrentContextBase.LoadEntitiesByPage(conditions, orderBy, pageSize, pageIndex);
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
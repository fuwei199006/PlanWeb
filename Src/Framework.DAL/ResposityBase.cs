

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


        public virtual T Find<T>(params object[] keyValues) where T : ModelBase
        {
            return this.CurrentContextBase.Find<T>(keyValues);
        }
        public T Get(Expression<Func<T, bool>> conditions) 
        {
            return this.CurrentContextBase.Get(conditions);
        }
        public T GetNoTracking(Expression<Func<T, bool>> conditions) 
        {
            return this.CurrentContextBase.GetNoTracking(conditions);
        }
        public virtual List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentContextBase.FindAll(conditions);
        }
        public virtual List<T> FindAllNoTracking<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            return this.CurrentContextBase.FindAllNoTracking(conditions);
        }
        public virtual PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            return this.CurrentContextBase.FindAllByPage(conditions, orderBy, pageSize, pageIndex);
        }
        #endregion

        #region  扩展方法

        public virtual T GetById(int id)
        {
            return this.Get(r => r.Id == id);
        }
        public virtual T GetByIdNoTracking(int id)
        {
            return this.GetNoTracking(r => r.Id == id);
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
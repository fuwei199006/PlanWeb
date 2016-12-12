

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

        //public virtual DbContextBase CurrentContextBase { get; set; }
        public abstract DbContextBase CreateDbContext();

        #region 基础的代码封装
        public virtual T Add(T entity)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.Add(entity);
            }

        }
        public virtual void AddRange(IList<T> entities)
        {
            using (var dbcontext = CreateDbContext())
            {
                dbcontext.AddRange(entities);
            }

        }

        public virtual T Update(T entity)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.Update(entity);
            }
        }
        public virtual void UpdateRang(IList<T> entities)
        {
            using (var dbcontext = CreateDbContext())
            {
                dbcontext.UpdateRang(entities);
            }
        }
        public virtual T Delete(T entity)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.Delete(entity);
            }
        }
        public virtual void DeleteRang(IList<T> entities)
        {
            using (var dbcontext = CreateDbContext())
            {
                dbcontext.DeleteRange(entities);
            }

        }




        public T GetEntity(Expression<Func<T, bool>> conditions)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.GetEntity(conditions);
            }

        }
        public T GetEntityWithNoTracking(Expression<Func<T, bool>> conditions)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.GetEntityWithNoTracking(conditions);
            }

        }

        public virtual List<T> LoadEntitiesNoTracking(Expression<Func<T, bool>> conditions = null)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.LoadEntitiesNoTracking(conditions).ToList();
            }


        }

        public virtual List<T> LoadEntities(Expression<Func<T, bool>> conditions = null)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.LoadEntities(conditions).ToList();
            }

        }
        public virtual PagedList<T> LoadEntitiesByPage<S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.LoadEntitiesByPage(conditions, orderBy, pageSize, pageIndex);
            }

        }
        #endregion

        #region  扩展方法

        public virtual T GetEntityById(int id)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.GetEntity<T>(r => r.Id == id);
            }
        }
        public virtual T GetEntityByIdNoTracking(int id)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.GetEntityWithNoTracking<T>(r => r.Id == id);
            }
        }

        public virtual List<T> GetEntities(IList<int> ids)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.LoadEntities<T>(r => ids.Contains(r.Id)).ToList();
            }
        }
        public virtual List<T> GetEntitiesNoTracking(IList<int> ids)
        {
            using (var dbcontext = CreateDbContext())
            {
                return dbcontext.LoadEntitiesNoTracking<T>(r => ids.Contains(r.Id)).ToList();
            }
        }
        public virtual void DeleteEntities(IList<int> ids)
        {
            using (var dbcontext = CreateDbContext())
            {
                var entities = LoadEntities(r => ids.Contains(r.Id));
                dbcontext.DeleteRange(entities.ToList());
            }

        }




        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using Framework.Contract;

namespace Framework.DbDrive.EntityFramework
{
    public interface IDataRepository
    {
        T Inser<T>(T entity) where T : ModelBase;
        T Update<T>(T entity) where T : ModelBase;
        T Delete<T>(T entity) where T : ModelBase;
        T Finde<T>(params object[] keyValues) where T : ModelBase;
        List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase; 
        PagedList<T> FindAllByPage<T,S>(Expression<Func<T,bool>> conditions,Expression<Func<T,S>>orderBy,int pageSize,int pageIndex ) where T : ModelBase;
    }
}
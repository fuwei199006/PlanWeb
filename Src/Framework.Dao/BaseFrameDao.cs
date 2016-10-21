using Framework.Dao;
using Framework.DbDrive.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Framework.Dao
{
    public abstract class BaseFrameDao<F>: IBaseFrameDao<F> where F:class
    {
        protected virtual DbContextBase CurrentContextBase { get; set; }

        public BaseFrameDao()
        {
            SetCurrentDbContext();
        }
        public List<F> ExceSql<F>(string sql) where F:class
        {
            return CurrentContextBase.ExceSql<F>(sql).ToList();
        }

        public List<F> ExceSql<F>(string sql, SqlParameter[] parameters) where F : class
        {
            return CurrentContextBase.ExceSql<F>(sql, parameters).ToList(); 
        }
        //public PagedList<F> ExceSqlPagedList<F>(string sql, int pageSize, int pageIndex) where F : class
        //{
        //    return CurrentContextBase.ExceSqlPagedList<F>(sql, pageSize, pageIndex);
        //}
        public abstract void SetCurrentDbContext();

       
    }
}

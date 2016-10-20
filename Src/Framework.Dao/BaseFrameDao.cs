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
    public abstract class BaseFrameDao<T>: IBaseFrameDao<T> where T:class
    {
        protected virtual DbContextBase CurrentContextBase { get; set; }

        public List<T> ExceSql(string sql) 
        {
            return CurrentContextBase.ExceSql<T>(sql).ToList();
        }

        public List<T> ExceSql(string sql, SqlParameter[] parameters)  
        {
            return CurrentContextBase.ExceSql<T>(sql, parameters).ToList();
        }

        public abstract void SetCurrentDbContext();

       
    }
}

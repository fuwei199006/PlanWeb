using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dao
{
    public interface IBaseFrameDao<F>
    {

          List<F> ExceSql<F>(string sql) where F : class;
          List<F> ExceSql<F>(string sql, SqlParameter[] parameters) where F : class;
           //PagedList<F> ExceSqlPagedList<F>(string sql, int pageSize, int pageIndex) where F : class;

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dao
{
    public interface IBaseFrameDao<T>
    {

          List<T> ExceSql(string sql);
          List<T> ExceSql(string sql, SqlParameter[] parameters);

    }
}

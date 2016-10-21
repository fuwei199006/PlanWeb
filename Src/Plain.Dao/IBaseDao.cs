using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dao
{
    public interface IBaseDao<T>
    {
        List<F> ExceSql<F>(string sql) where F : class;
        List<F> ExceSql<F>(string sql, SqlParameter[] parameters) where F : class;

    }
}

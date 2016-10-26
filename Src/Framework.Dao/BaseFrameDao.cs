using Framework.Dao;
using Framework.DbDrive.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Framework.Contract;

namespace Framework.Dao
{
    public abstract class BaseFrameDao<F> : IBaseFrameDao<F> where F : class
    {
        protected virtual DbContextBase CurrentContextBase { get; set; }

        public BaseFrameDao()
        {
            SetCurrentDbContext();
        }
        public List<F> ExceSql<F>(string sql) where F : class
        {
            return CurrentContextBase.ExceSql<F>(sql).ToList();
        }

        public List<F> ExceSql<F>(string sql, SqlParameter[] parameters) where F : class
        {
            return CurrentContextBase.ExceSql<F>(sql, parameters).ToList();
        }
        public PagedList<F> ExceSqlPagedList<F>(string sql, int pageSize, int pageIndex) where F : class
        {
            return CurrentContextBase.ExceSqlPagedList<F>(sql, pageSize, pageIndex);
        }

        private string GetPageSql(string sql, int pageSize, int pageIndex, string pkName, bool isCount)
        {
            var resultSql = new StringBuilder();
            var pageStar = (pageIndex - 1) * pageSize;
            var pageEnd = pageIndex * pageSize;
            if (pageIndex == 1)
            {
                resultSql.AppendFormat(@"SELECT TOP +cast ({0} AS VARCHAR)  * FROM ( {1}  ) myTable order by   {2} ;", pageSize, sql, pkName);
            }
            else
            {
                resultSql.AppendFormat(
                    @"SELECT * from (select *,ROW_NUMBER() Over(order by {0}) as rowNum from ({1}) as myInTable ) as myTable  where rowNum between convert( nvarchar(8 ),{2})   and convert (nvarchar( 8),{3} );",
                    pkName, sql, pageStar, pageEnd);
            }
            if (isCount)
            {
                resultSql.AppendFormat("'SELECT count(1) from  ({0} ) as myTable'", sql);
            }
            return resultSql.ToString();
        }
        public abstract void SetCurrentDbContext();


    }
}

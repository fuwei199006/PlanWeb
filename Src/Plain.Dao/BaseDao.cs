using System;
using Framework.Dao;
using Core.Service;
using Plain.DAL;
using Framework.DbDrive.EntityFramework;
using System.Collections.Generic;

namespace Plain.Dao
{
    public class BaseDao<T> : BaseFrameDao<T>, IBaseDao<T> where T:class
    {
        public override DbContextBase CreateDbContext()
        {
          return  ServiceContext.CreateService<PlainDbContext>();
        }
    }
}

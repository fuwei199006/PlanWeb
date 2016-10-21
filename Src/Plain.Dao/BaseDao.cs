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
 
        protected override DbContextBase CurrentContextBase { get; set; }
        public BaseDao()
        {
            SetCurrentDbContext();
        }
        public override sealed void SetCurrentDbContext()
        {

            CurrentContextBase = ServiceContext.CreateService<PlainDbContext>() as PlainDbContext;

        }
      

    }
}

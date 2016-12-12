using Core.Cache;
using Core.Service;
using Framework.Contract;
using Framework.DAL;
using Framework.DbDrive.EntityFramework;

namespace Plain.DAL
{
    public class BaseResposity<T> : ResposityBase<T>, IBaseResposity<T> where T : ModelBase
    {


        public override DbContextBase CreateDbContext()
        {
          return  ServiceContext.CreateService<PlainDbContext>(new ContextServiceFactory());
        }
    }
}
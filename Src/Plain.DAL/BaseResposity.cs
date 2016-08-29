using Core.Cache;
using Core.Service;
using Framework.Contract;
using Framework.DAL;

namespace Plain.DAL
{
    public class BaseResposity<T> : ResposityBase<T>,IBaseResposity<T> where T : ModelBase
    {
        public BaseResposity()
        {
            SetCurrentDbContext();
        }
        public override sealed void SetCurrentDbContext()
        {
        #if DEBUG
            CurrentContextBase = ServiceContext.Current.CreateService<PlainDbContext>();
        #endif 
        #if !DEBUG
           CurrentContextBase = ServiceContext.CreateService<PlainDbContext>();
        #endif
            }
        }
}
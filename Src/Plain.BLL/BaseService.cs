


using Core.Service;
using Framework.BLL;
using Framework.Contract;
using Plain.DAL;

namespace Plain.BLL
{
    public class BaseService<T> : ServiceBase<T>, IBaseService<T> where T : ModelBase
    {

        public BaseService()
        {
            SetCurrentResposity();
        }
        public override sealed void SetCurrentResposity()
        {
            #if DEBUG
                    this.CurrentResposity = ServiceContext.CreateService<BaseResposity<T>>();
            #endif
            #if !DEBUG
                this.CurrentResposity = ServiceContext.Current.CreateService<BaseResposity<T>>();
            #endif

        }
    }
}
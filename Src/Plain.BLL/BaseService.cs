


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
        protected override sealed void SetCurrentResposity()
        {

            this.CurrentResposity = ServiceContext.CreateService<BaseResposity<T>>();


        }
    }
}
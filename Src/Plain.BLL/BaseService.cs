


using Core.Service;
using Framework.BLL;
using Framework.Contract;
using Framework.DAL;
using Plain.DAL;

namespace Plain.BLL
{
    public class BaseService<T> : ServiceBase<T>, IBaseService<T> where T : ModelBase
    {


        public BaseService() : base(ServiceContext.CreateService<BaseResposity<T>>())
        {

        }
         
    }
}
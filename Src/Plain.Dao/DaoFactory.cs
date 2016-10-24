using Core.Service;
using Plain.Dao.MenuDao;

namespace Plain.Dao
{
    public class DaoFactory
    {
        public static IMenuDao MenuDao
        {
            get { return ServiceContext.Current.CreateService<IMenuDao>(); }

        }
    }
}
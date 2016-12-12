using Framework.DbDrive.EntityFramework;

namespace Plain.DAL
{
    public interface IBaseResposity<T>
    {
          DbContextBase CreateDbContext();
    }
}
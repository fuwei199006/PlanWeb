using Framework.Contract;
using Plain.Model.Models;
using Plain.Model.Models.Model;

namespace Plain.BLL.UserService
{
    public interface IUserService:IBaseService<Basic_UserInfo>
    {
        Basic_UserInfo AddUser(Basic_UserInfo user);

        Basic_UserInfo GetUserByEmail(string email);
        Basic_UserInfo ActiveUserByEmail(string email);
        Basic_UserInfo  EmailExist(string email);
        Basic_UserInfo  UserPass(string loginName,string pwd);

        Basic_UserInfo GetUserByUserId(int id);
        PagedList<Basic_UserInfo> GetUserByPage(string userName, int pageSize, int pageIndex);

    }
}
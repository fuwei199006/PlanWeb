using Plain.Model.Models;

namespace Plain.BLL.UserService
{
    public interface IUserService:IBaseService<Basic_UserInfo>
    {
        Basic_UserInfo AddUser(Basic_UserInfo user);

        Basic_UserInfo GetUserByEmail(string email);
        Basic_UserInfo ActiveUserByEmail(string email);
        Basic_UserInfo  EmailExist(string email);

    }
}
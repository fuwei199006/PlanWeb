using Plain.Model.Models;

namespace Plain.BLL.UserService
{
    public class UserService:BaseService<Basic_UserInfo>,IUserService
    {
        public Basic_UserInfo AddUser(Basic_UserInfo user)
        {
           return this.CurrentResposity.Add(user);
        }

        public Basic_UserInfo GetUserByEmail(string email)
        {
             return this.CurrentResposity.GetNoTracking(r => r.UserEmail == email&&r.UserStaus==1);
            
        }
    }
}
using System;
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
             return this.CurrentResposity.GetNoTracking(r => r.UserEmail == email&&r.UserStaus==0);
            
        }

        public Basic_UserInfo ActiveUserByEmail(string email)
        {
           var result= this.CurrentResposity.Get(r => r.UserEmail == email && r.UserStaus == 0);
            if (result == null) return null;
            result.UserStaus = 1;//Active User
            result.ModifyTime = DateTime.Now;
        
            return this.CurrentResposity.Update(result);
        }

        public Basic_UserInfo EmailExist(string email)
        {
            return this.CurrentResposity.GetNoTracking(r => r.UserEmail == email);
        }

    }
}
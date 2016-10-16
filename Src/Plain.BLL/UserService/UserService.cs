using System;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Linq;

namespace Plain.BLL.UserService
{
    public class UserService:BaseService<Basic_UserInfo>,IUserService
    {
        public Basic_UserInfo AddUser(Basic_UserInfo user)
        {
           return this.Add(user);
        }

        public Basic_UserInfo GetUserByEmail(string email)
        {
             return this.GetEntityWithNoTracking(r => r.UserEmail == email&&r.UserStaus==1);
            
        }

        public Basic_UserInfo ActiveUserByEmail(string email)
        {
           var result= this.GetEntity(r => r.UserEmail == email && r.UserStaus == 0);
            if (result == null) return null;
            result.UserStaus = 1;//Active User
            result.ModifyTime = DateTime.Now;
        
            return this.Update(result);
        }

        public Basic_UserInfo EmailExist(string email)
        {
            return this.GetEntityWithNoTracking(r => r.UserEmail == email);
        }

        public Basic_UserInfo UserPass(string loginName, string pwd)
        {
            return this.GetEntityWithNoTracking(r => r.LoginName == loginName && r.UserPwd == pwd && r.UserStaus == 1);
        }

        public Basic_UserInfo GetUserByUserId(int id)
        {
            return this.GetEntityById(id);
        }
    }
}
using System;
using System.Collections.Generic;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Linq;
using Framework.Contract;
using Plain.Dto;

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
            result.UserStaus = (int)UserStausType.Active;//Active User
            result.ModifyTime = DateTime.Now;
        
            return this.Update(result);
        }

        public Basic_UserInfo EmailExist(string email)
        {
            return this.GetEntityWithNoTracking(r => r.UserEmail == email);
        }

        public Basic_UserInfo UserPass(string loginName, string pwd)
        {
            return this.GetEntityWithNoTracking(r => r.LoginName == loginName && r.UserPwd == pwd && r.UserStaus == (int)UserStausType.Active);
        }

        public Basic_UserInfo GetUserByUserId(int id)
        {
            return this.GetEntityById(id);
        }

        public PagedList<Basic_UserInfo> GetUserByPage(string userName, int pageSize, int pageIndex)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return this.LoadEntitiesByPage(r => true, r => r.Id, pageSize, pageIndex);
            }
            return this.LoadEntitiesByPage(r => r.LoginName.Contains(userName), r=>r.Id, pageSize, pageIndex);
        }

        public Basic_UserInfo UpdateUser(Basic_UserInfo userInfo)
        {
           return this.Update(userInfo);
        }

        public void DeleteUser(List<int> ids)
        {
             this.DeleteEntities(ids);
            
        }
    }
}
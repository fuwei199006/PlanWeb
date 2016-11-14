using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models.Model;
using System;

namespace Plain.BLL.UserRoleService
{
    public class UserRoleService : BaseService<Basic_UserRole>, IUserRoleService
    {
        public List<Basic_UserRole> GetUserRolesByUserId(int userId)
        {
            return this.LoadEntitiesNoTracking(r => r.UserId == userId && r.MappingStatus).ToList();
        }

        public void AddUserRole(List<Basic_UserRole> userRoles)
        {
            if (userRoles.Any())
            {
                DeleteUserRoles(userRoles.FirstOrDefault().UserId);
                this.AddRange(userRoles);
            }
         
        }

        /// <summary>
        /// 使用逻辑删除
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUserRoles(int userId)
        {
            var userRoles = this.GetUserRolesByUserId(userId);
            foreach (var basicUserRole in userRoles)
            {
                basicUserRole.MappingStatus = false;
                basicUserRole.ModifyTime = DateTime.Now;
            }
            this.UpdateRang(userRoles);
        }
    }
}
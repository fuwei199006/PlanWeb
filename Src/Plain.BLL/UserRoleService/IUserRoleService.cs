using System.Collections.Generic;
using Plain.Model.Models.Model;

namespace Plain.BLL.UserRoleService
{
    public interface IUserRoleService
    {
        List<Basic_UserRole> GetUserRolesByUserId(int userId);

        void AddUserRole(List<Basic_UserRole> userRoles);

        void DeleteUserRoles(int userId);
    }
}
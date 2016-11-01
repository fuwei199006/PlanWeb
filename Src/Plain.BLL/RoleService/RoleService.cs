using Framework.Contract;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.RoleService
{
   public class RoleService : BaseService<Basic_Role>,IRoleService
    {
        public Basic_Role AddRole(Basic_Role role)
        {
           return this.Add(role);
        }

        public void DeleteRoles(List<int> ids)
        {
            this.DeleteEntities(ids);
        }

        public Basic_Role GetRoleById(int id)
        {
            return GetEntityById(id);
        }

        public PagedList<Basic_Role> GetRoleListByPage(RoleRequest request)
        {
            if (string.IsNullOrEmpty(request.RoleName))
            {
                return this.LoadEntitiesByPage(r =>true, r => r.Id, request.PageSize, request.PageIndex);
            }
            return this.LoadEntitiesByPage(r => r.RoleName.Contains(request.RoleName), r => r.Id, request.PageSize, request.PageIndex);
        }

        public Basic_Role UpdateRole(Basic_Role role)
        {
            return this.Update(role);
        }
    }
}

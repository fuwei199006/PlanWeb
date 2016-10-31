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
    public interface IRoleService
    {
        PagedList<Basic_Role> GetRoleListByPage(RoleRequest request);

        Basic_Role AddRole(Basic_Role role);
        Basic_Role GetRoleById(int id);

        Basic_Role UpdateRole(Basic_Role role);
    }
}

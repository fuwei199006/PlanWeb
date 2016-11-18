using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.PowerRoleService
{
   public interface IPowerRoleService
    {
        List<Basic_PowerRole> GetPowerRolesByRoleId(int roleId);

        void AddPowerRoleRange(List<Basic_PowerRole> powerRoles);

        void DeletePowerRoleByRoleId(int roleId);
       
    }
}

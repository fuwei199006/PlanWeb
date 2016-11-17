using System;
using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models.Model;

namespace Plain.BLL.PowerRoleService
{
    public class PowerRoleService : BaseService<Basic_PowerRole>, IPowerRoleService
    {
        public List<Basic_PowerRole> GetPowerRolesByRoleId(int roleId)
        {
            return this.LoadEntitiesNoTracking(r => r.RoleId == roleId&&r.MappingStatus).ToList();
        }

        public void AddPowerRoleRange(List<Basic_PowerRole> powerRoles)
        {
             this.AddRange(powerRoles);
        }

        public void DeletePowerRoleByRoleId(int roleId)
        {
            var powerRoleList = this.LoadEntities(r => r.RoleId == roleId && r.MappingStatus).ToList();
            foreach (var basicPowerRole in powerRoleList)
            {
                basicPowerRole.MappingStatus = false;
                basicPowerRole.ModifyTime=DateTime.Now;
            }
            this.UpdateRang(powerRoleList);
        }
    }
}

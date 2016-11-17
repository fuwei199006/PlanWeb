using Core.Service;
using Framework.Contract;
using Plain.BLL.PowerService;
using Plain.Dto;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.BLL.PowerRoleService;

namespace Plain.BLL.RoleService
{
   public class RoleService : BaseService<Basic_Role>,IRoleService
    {
       public List<Basic_Role> GetRoleListByRoleIds(List<int> ids)
       {
           return this.LoadEntities(r => ids.Contains(r.Id) && r.RoleStatus == (int)StatusType.Enable).ToList();
       }

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
            var role= GetEntityById(id);
            var powerIds = ServiceContext.Current.CreateService<IPowerRoleService>().GetPowerRolesByRoleId(role.Id).Select(x => x.PowerId).ToList();
            role.Powers =
                ServiceContext.Current.CreateService<IPowerService>().GetPowerListBtPowerIds(powerIds).ToList();
            return role;
        }

        public List<Basic_Role> GetRoleList()
        {
            return this.LoadEntitiesNoTracking(r => r.RoleStatus == (int)StatusType.Enable).ToList();
        }

        public PagedList<Basic_Role> GetRoleListByPage(RoleRequest request)
        {
            PagedList<Basic_Role> pageRoles = null;
            pageRoles = string.IsNullOrEmpty(request.RoleName) ? this.LoadEntitiesByPage(r => true && r.RoleStatus == (int)StatusType.Enable, r => r.Id, request.PageSize, request.PageIndex) : this.LoadEntitiesByPage(r => r.RoleName.Contains(request.RoleName) && r.RoleStatus == (int)StatusType.Enable, r => r.Id, request.PageSize, request.PageIndex);
        

            foreach (var item in pageRoles)
            {
                var powerIds = ServiceContext.Current.CreateService<IPowerRoleService>().GetPowerRolesByRoleId(item.Id).Select(x=>x.PowerId).ToList();
                item.Powers =
                    ServiceContext.Current.CreateService<IPowerService>().GetPowerListBtPowerIds(powerIds).ToList();
              
            }
            return pageRoles;
        }

        public Basic_Role UpdateRole(Basic_Role role)
        {
            return this.Update(role);
        }
    }
}

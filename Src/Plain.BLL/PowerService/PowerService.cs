using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Framework.Contract;
using Core.Service;
using Plain.BLL.PowerMenuService;
using Plain.BLL.MenuService;

namespace Plain.BLL.PowerService
{
    public class PowerService : BaseService<Basic_Power>, IPowerService
    {
        public Basic_Power AddPower(Basic_Power power)
        {
            return this.Add(power);
        }

        public void DeletePower(List<int> ids)
        {
            this.DeleteEntities(ids);
        }

        public IQueryable<Basic_Power> GetPowerListBtPowerIds(List<int> ids)
        {
            return this.LoadEntitiesNoTracking(r => ids.Contains(r.Id));
        }

        public Basic_Power GetPowerById(int id)
        {
            var power= this.GetEntityById(id);
            var menuIds = ServiceContext.Current.CreateService<IPowerMenuService>().GetPowerMenusByPowerId(power.Id).Select(x => x.MenuId).ToList();
            var menus = ServiceContext.Current.CreateService<IMenuService>().GetMenuByIds(menuIds);
            power.Menus = menus;
            return power;
        }

        public List<Basic_Power> GetPowerList()
        {
            return this.LoadEntitiesNoTracking(r=>r.PowerStatus==1).ToList();
        }

        public PagedList<Basic_Power> GetPowerPage(PowerRequest request)
        {
            PagedList<Basic_Power> pageList = null;
            if (string.IsNullOrEmpty(request.PowerName))
            {
                pageList= this.LoadEntitiesByPage(r => true, r => r.CreateTime, request.PageSize, request.PageIndex);
            }
            else
            {
                pageList = this.LoadEntitiesByPage(r => r.PoweName.Contains(request.PowerName), r => r.CreateTime, request.PageSize, request.PageIndex);
            }

            foreach (var item in pageList)
            {

                var menuIds = ServiceContext.Current.CreateService<IPowerMenuService>().GetPowerMenusByPowerId(item.Id).Select(x => x.MenuId).ToList();
                var menus = ServiceContext.Current.CreateService<IMenuService>().GetMenuByIds(menuIds);
                item.Menus = menus;
            }

            return pageList;

        }

        public Basic_Power UpdatePower(Basic_Power power)
        {
            return this.Update(power);
        }
    }
}

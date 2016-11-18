using Framework.BLL;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.PowerMenuService
{
    public class PowerMenuService : BaseService<Basic_PowerMenu>, IPowerMenuService
    {
        public void AddPowerMenuRang(List<Basic_PowerMenu> powerMenus)
        {
             this.AddRange(powerMenus);
        }

        public void DeleteByMenuId(int menuId)
        {
            var powers = this.GetPowerMenusByMenuId(menuId).ToList();
            this.DeletePowerMenus(powers);

        }

        public void DeleteByPowerId(int powerId)
        {
            var powers = this.GetPowerMenusByPowerId(powerId).ToList();
            this.DeletePowerMenus(powers);
        }

        public void DeletePowerMenus(List<Basic_PowerMenu> powerMenus)
        {
            foreach (var item in powerMenus)
            {
                item.MappingStatus = false;
                item.ModifyTime = DateTime.Now;
            }
            this.UpdateRang(powerMenus);

        }

        public IQueryable<Basic_PowerMenu> GetPowerMenusByMenuId(int menuId)
        {
            return this.LoadEntities(r => r.MenuId == menuId && r.MappingStatus);
        }

        public IQueryable<Basic_PowerMenu> GetPowerMenusByPowerId(int powerId)
        {
            return this.LoadEntities(r => r.PowerId == powerId && r.MappingStatus);
        }

        public Basic_PowerMenu AddPowerMenu(Basic_PowerMenu powerMenu)
        {
            return this.Add(powerMenu);
        }

        public void ClearPowerMenu()
        {
            this.DeletePowerMenus(this.LoadEntities().ToList());
        }
    }
}

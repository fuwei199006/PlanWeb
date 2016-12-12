using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.PowerMenuService
{
   public interface IPowerMenuService : IBaseService<Basic_PowerMenu>
    {

        void  AddPowerMenuRang(List<Basic_PowerMenu> powerMenus);
        Basic_PowerMenu  AddPowerMenu(Basic_PowerMenu powerMenu);
        void DeleteByPowerId(int powerId);
        void DeleteByMenuId(int menuId);

        List<Basic_PowerMenu> GetPowerMenusByPowerId(int powerId);
        List<Basic_PowerMenu> GetPowerMenusByMenuId(int menuId);

        void DeletePowerMenus(List<Basic_PowerMenu> powerMenus);

        void ClearPowerMenu();
  
    }
}

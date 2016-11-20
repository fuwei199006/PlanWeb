using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contract;
using Plain.Model.Models.Model;

namespace Plain.Dao.MenuDao
{
    public interface IMenuDao
    {
        PagedList<Basic_MenuDto> GetMenuDto(string menuName, int pageSize, int pageIndex);

        List<Basic_Menu> GetMenuByUserName(string loginName);
    }
}

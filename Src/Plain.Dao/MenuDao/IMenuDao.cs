using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contract;

namespace Plain.Dao.MenuDao
{
    public interface IMenuDao
    {
        PagedList<Basic_MenuDto> GetMenuDto(string menuName, int pageSize, int pageIndex);
    }
}

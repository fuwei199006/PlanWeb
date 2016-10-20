using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dao.MenuDao
{
   public interface IMenuDao 
    {
        List<Basice_MenuDto> GetMenuDtos();
    }
}

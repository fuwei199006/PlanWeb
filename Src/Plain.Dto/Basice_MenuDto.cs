using Plain.Dto;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto
{
    public class Basice_MenuDto:Basic_Menu
    {
        public string ParentMenuName { get; set; }

        public string ParentMenuType { get; set; }
    }
}

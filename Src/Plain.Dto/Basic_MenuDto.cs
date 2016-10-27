using Framework.Contract;
using Plain.Dto;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto
{
    public class Basic_MenuDto:ModelBase
    {

        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuType { get; set; }
        public Nullable<int> MenuSort { get; set; }
        public Nullable<int> MenuParentId { get; set; }
        public int  MenuStatus { get; set; }
        public string ParentMenuName { get; set; }
        public string ParentMenuType { get; set; }
        public string MenuIcon { get; set; }
    }
}

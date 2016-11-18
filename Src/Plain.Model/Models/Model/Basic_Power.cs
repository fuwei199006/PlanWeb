using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Power : ModelBase
    {

        public string PoweName { get; set; }
        public int PowerStatus { get; set; }
        public string PowerGroup { get; set; }
        public DateTime ModifyTime { get; set; }
        [NotMapped]
        public List<Basic_Menu> Menus { get; set; }

        [NotMapped]
        public List<int> MenuIds
        {
            get
            {
                return Menus.Select(x => x.Id).ToList();
            }
        }
    }
}

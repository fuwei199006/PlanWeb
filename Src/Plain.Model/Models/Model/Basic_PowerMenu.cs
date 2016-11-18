using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plain.Model.Models.Model
{
    public partial class Basic_PowerMenu : ModelBase
    {
        public int PowerId { get; set; }
        public int MenuId { get; set; }
        public bool MappingStatus { get; set; }
        public System.DateTime ModifyTime { get; set; }

   
    }
}

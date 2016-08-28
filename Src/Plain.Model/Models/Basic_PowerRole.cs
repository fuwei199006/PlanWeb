using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_PowerRole : ModelBase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PowerId { get; set; }
        public Nullable<bool> MappingStatus { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

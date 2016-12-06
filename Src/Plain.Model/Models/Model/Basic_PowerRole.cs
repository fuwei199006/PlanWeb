using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    [Serializable]
    public partial class Basic_PowerRole : ModelBase
    {

        public int RoleId { get; set; }
        public int PowerId { get; set; }
        public bool MappingStatus { get; set; }

        public System.DateTime ModifyTime { get; set; }
    }
}

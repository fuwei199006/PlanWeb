using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Role : ModelBase
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> RoleStatus { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}
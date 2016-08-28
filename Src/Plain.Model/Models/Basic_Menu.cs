using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Menu : ModelBase
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuType { get; set; }
        public Nullable<int> MenuSort { get; set; }
        public Nullable<int> MenuParentId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Dictionary : ModelBase
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FieldRemark { get; set; }
        public Nullable<bool> DicStatus { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

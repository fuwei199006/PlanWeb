using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Power : ModelBase
    {
        public int Id { get; set; }
        public string PoweName { get; set; }
        public Nullable<bool> PowerStatus { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

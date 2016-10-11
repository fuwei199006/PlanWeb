using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_MainData : ModelBase
    {
        public int Id { get; set; }
        public string MainKey { get; set; }
        public string MainCode { get; set; }
        public string MainData { get; set; }
        public bool MainStatus { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

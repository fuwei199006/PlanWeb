using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Task : ModelBase
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public System.DateTime StarTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Nullable<bool> TaskStatus { get; set; }
        public Nullable<System.DateTime> ExecTime { get; set; }
        public Nullable<System.DateTime> ExecEndTime { get; set; }
        public string ReturnMsg { get; set; }
    }
}

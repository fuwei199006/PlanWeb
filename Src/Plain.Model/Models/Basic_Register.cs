using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Register : ModelBase
    {
        public int Id { get; set; }
        public string RegisterName { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public Nullable<bool> RegisterStatus { get; set; }
        public string RegisterDevice { get; set; }
        public string RetisterIp { get; set; }
    }
}

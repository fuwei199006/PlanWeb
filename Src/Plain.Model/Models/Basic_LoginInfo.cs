using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_LoginInfo : ModelBase
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<System.DateTime> ExpireTime { get; set; }
        public string LoginIp { get; set; }
        public string LoginHeader { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }

        public string LoginToken { get; set; }
    }
}

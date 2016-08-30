using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_LoginInfo : ModelBase
    {
        public int Id { get; set; }
        public int LoginUserId { get; set; }
        public string LoginName { get; set; }
        public int LoginStatus { get; set; }
        public int LoginType { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<System.DateTime> ExpireTime { get; set; }
        public string LoginIp { get; set; }
        public string LoginHeader { get; set; }
        public  bool  IsDelete { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }

        public Guid LoginToken { get; set; }
    }
}

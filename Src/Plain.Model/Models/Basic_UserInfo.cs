using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_UserInfo : ModelBase
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        public string RealName { get; set; }
        public string RegisterDevice { get; set; }
        public string RegisterIp { get; set; }
        public string RegiserHeader { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<int> UserStaus { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}

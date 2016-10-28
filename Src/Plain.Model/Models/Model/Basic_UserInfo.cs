using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Contract;
using System.ComponentModel.DataAnnotations;

namespace Plain.Model.Models.Model
{
    public partial class Basic_UserInfo : ModelBase
    {
 
        public string LoginName { get; set; }
        public string NickName { get; set; }
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        [Required(ErrorMessage = "��������Ϊ��")]
        public string RealName { get; set; }
        [NotMapped]
        public string Age { get; set; }
        public Nullable<int> UserStaus { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthDay { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Addr { get; set; }
        public string OtherInfo { get; set; }
        public int? Sex  { get; set; }
    }
}

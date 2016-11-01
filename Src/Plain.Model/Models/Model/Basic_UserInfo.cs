using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_UserInfo : ModelBase
    {
        public string LoginName { get; set; }
        public string NickName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "电子邮件地址无效")]
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        [Required(ErrorMessage = "真实姓名不能为空")]
        public string RealName { get; set; }
        [NotMapped]
        public string Age { get; set; }
        public Nullable<int> UserStaus { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthDay { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Addr { get; set; }
        public string OtherInfo { get; set; }
        public int Sex { get; set; }
    }
}

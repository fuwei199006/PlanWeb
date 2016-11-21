using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_UserInfo : ModelBase
    {

        public Basic_UserInfo()
        {
            this.Roles=new List<Basic_Role>();
        }
        public string LoginName { get; set; }
        public string NickName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "电子邮件地址无效")]
        [Required(ErrorMessage = "电子邮件地址不能为空")]
        public string UserEmail { get; set; }
        public string UserPwd { get; set; }
        [Required(ErrorMessage = "真实姓名不能为空")]
        public string RealName { get; set; }
        [NotMapped]
        public string Age { get; set; }
        public int UserStaus { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthDay { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Addr { get; set; }
        public string OtherInfo { get; set; }
        public int Sex { get; set; }


        [NotMapped]
        public List<Basic_Role> Roles { get; set; }

        [NotMapped]
        public List<int> RoleIds
        {
            get { return this.Roles.Select(x => x.Id).ToList(); }
        }

        [NotMapped]
        public List<Basic_PowerRole> Powers { get; set; } 

    }
}

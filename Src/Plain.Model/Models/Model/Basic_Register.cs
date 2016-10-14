using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Register : ModelBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "昵称不能为空")]
        public string RegisterName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "电子邮件地址无效")]
        [Required(ErrorMessage = "电子邮件不能为空")]
        [Remote("ValideUser", "Login", ErrorMessage = "该邮箱已经注册")]
        public string RegisterEmail { get; set; }
        //[RegularExpression(@"^[1]\d{10}$", ErrorMessage = "请输入正确的手机号")]
        public string RegisterPhone { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(200,ErrorMessage = "密码长度不能小于6位", MinimumLength = 6)]
        public string RegisterPassword { get; set; }

        [Required(ErrorMessage = "确认密码不能为空")]
        [System.ComponentModel.DataAnnotations.Compare("RegisterPassword", ErrorMessage = "两次密码输入不一致")]
        [StringLength(200, ErrorMessage = "密码长度不能小于6位", MinimumLength = 6)]

        [NotMapped]
        public string RegisterConfirmPassword { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public  bool  RegisterStatus { get; set; }
        public string RegisterDevice { get; set; }
        public string RetisterIp { get; set; }
        public Guid RegisterToken { get; set; }
        

        //[Required(ErrorMessage = "验证码不能为空")]
        //[NotMapped]
        //public string _Code { get; set; }
    }
}

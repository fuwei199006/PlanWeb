using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Register : ModelBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "昵称不能为空")]
        public string RegisterName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "电子邮件地址无效")]
        [Required(ErrorMessage = "电子邮件不能为空")]
         public string RegisterEmail { get; set; }
        [RegularExpression(@"^[1]\d{10}$", ErrorMessage = "请输入正确的手机号")]
        public string RegisterPhone { get; set; }
        public string RegisterPassword { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public  bool  RegisterStatus { get; set; }
        public string RegisterDevice { get; set; }
        public string RetisterIp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Register : ModelBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "�ǳƲ���Ϊ��")]
        public string RegisterName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "�����ʼ���ַ��Ч")]
        [Required(ErrorMessage = "�����ʼ�����Ϊ��")]
         public string RegisterEmail { get; set; }
        [RegularExpression(@"^[1]\d{10}$", ErrorMessage = "��������ȷ���ֻ���")]
        public string RegisterPhone { get; set; }
        public string RegisterPassword { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public  bool  RegisterStatus { get; set; }
        public string RegisterDevice { get; set; }
        public string RetisterIp { get; set; }
    }
}

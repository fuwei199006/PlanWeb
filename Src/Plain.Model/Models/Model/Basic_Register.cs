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
        [Required(ErrorMessage = "�ǳƲ���Ϊ��")]
        public string RegisterName { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "�����ʼ���ַ��Ч")]
        [Required(ErrorMessage = "�����ʼ�����Ϊ��")]
        [Remote("ValideUser", "Login", ErrorMessage = "�������Ѿ�ע��")]
        public string RegisterEmail { get; set; }
        //[RegularExpression(@"^[1]\d{10}$", ErrorMessage = "��������ȷ���ֻ���")]
        public string RegisterPhone { get; set; }
        [Required(ErrorMessage = "���벻��Ϊ��")]
        [StringLength(200,ErrorMessage = "���볤�Ȳ���С��6λ", MinimumLength = 6)]
        public string RegisterPassword { get; set; }

        [Required(ErrorMessage = "ȷ�����벻��Ϊ��")]
        [System.ComponentModel.DataAnnotations.Compare("RegisterPassword", ErrorMessage = "�����������벻һ��")]
        [StringLength(200, ErrorMessage = "���볤�Ȳ���С��6λ", MinimumLength = 6)]

        [NotMapped]
        public string RegisterConfirmPassword { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public  bool  RegisterStatus { get; set; }
        public string RegisterDevice { get; set; }
        public string RetisterIp { get; set; }
        public Guid RegisterToken { get; set; }
        

        //[Required(ErrorMessage = "��֤�벻��Ϊ��")]
        //[NotMapped]
        //public string _Code { get; set; }
    }
}

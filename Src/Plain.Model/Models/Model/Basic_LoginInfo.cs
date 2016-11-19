using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_LoginInfo : ModelBase
    {
        public Basic_LoginInfo()
        {
            
        }
        public Basic_LoginInfo(int userId, string loginName)
        {
            this.LoginUserId = userId;
            this.LoginName = loginName;
            this.LoginToken=Guid.NewGuid();
            CreateTime=DateTime.Now;
            LastUpdateTime=DateTime.Now;
            LoginTime=DateTime.Now;
            IsDelete = false;
            LoginStatus = 1;

        }
        public int Id { get; set; }
        public int LoginUserId { get; set; }
        [RegularExpression(@"^\w+\.?\w+@\w+\.\w+$", ErrorMessage = "�����ʼ���ַ��Ч")]
        [Required(ErrorMessage = "�����ʼ�����Ϊ��")]
        [Remote("ValideUser", "Login", ErrorMessage = "�������Ѿ�ע��")]
        public string LoginName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "��¼������Ϊ��")]
        public string LoginNameFor { get; set; }
        public int LoginStatus { get; set; }
        public int LoginType { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<System.DateTime> ExpireTime { get; set; }
        public string LoginIp { get; set; }
        public string LoginHeader { get; set; }
        public  bool  IsDelete { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }

        public Guid LoginToken { get; set; }

         [Required(ErrorMessage = "�ǳƲ���Ϊ��")]
        public string LoginNickName { get; set; }
    }
}

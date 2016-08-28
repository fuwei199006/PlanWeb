using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_MessageBox : ModelBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<int> MessageStatus { get; set; }
        public int ToUserId { get; set; }
        public string ToUserName { get; set; }
        public int FromUserId { get; set; }
        public string FromUserName { get; set; }
        public System.DateTime SentTime { get; set; }
    }
}

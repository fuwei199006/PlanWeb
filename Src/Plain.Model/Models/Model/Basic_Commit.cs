using System;
using Framework.Contract;
namespace Plain.Model.Models.Model
{
    public partial class Basic_Commit : ModelBase
    {

        public string Content { get; set; }
        public string CommitUserName { get; set; }
        public int CommitUserId { get; set; }
        public int? CommitType { get; set; }

        public DateTime? ModifyTime { get; set; }
        public int ArticleId { get; set; }

    }
}


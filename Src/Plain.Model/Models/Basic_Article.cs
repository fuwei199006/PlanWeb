using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models
{
    public partial class Basic_Article : ModelBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Sort { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string KeyWord { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTIme { get; set; }
        public Nullable<int> ArticleStatus { get; set; }
    }
}

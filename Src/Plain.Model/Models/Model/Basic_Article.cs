using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Article: ModelBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }
        public int Sort { get; set; }
        public string KeyWord { get; set; }
 
        public Nullable<System.DateTime> ModifyTIme { get; set; }
        public Nullable<int> ArticleStatus { get; set; }
    }
}

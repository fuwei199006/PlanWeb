using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Article: ModelBase
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }
        public int Sort { get; set; }
        public string KeyWord { get; set; }
 
        public DateTime ModifyTIme { get; set; }
        public  int  ArticleStatus { get; set; }

        public string Position { get; set; }
 
        [NotMapped]
        public List<Basic_Commit> CommitList { get; set; }
    }
}

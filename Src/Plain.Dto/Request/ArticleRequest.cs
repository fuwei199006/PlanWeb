using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto.Request
{
    public class ArticleRequest : Framework.Contract.Request
    {
        public ArticleRequest()
        {
            Top = 10;
        }
        public string Content { get; set; }
        public string Title { get; set; }
    } 
}

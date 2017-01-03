using Core.Service;
using Plain.BLL.Article;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.ArticleSpider
{
    public class BasicSpiderService
    {
        public static IArticleService _service { get { return ServiceContext.Current.CreateService<IArticleService>(); } }
        public static string DownPath
        {
            get { return Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/"); }
        }
    }
}

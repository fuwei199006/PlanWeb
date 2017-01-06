using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.ArticleSpider.Dtos
{
    public class WangyiBlogRegexKey
    {
        public const string ARegex = @"<a[^<>]+href=[^<>]+>[^<>]+</a>";//修改
        public const string BlogUrlRegex = @"http://[^<>]+\.blog\.163\.com\/blog\/static\/[^ ""\{\}\,\]\[\\]+";
        public const string BlogImgRegex = @"<img[^<>]+src[^<>]+>";

        public const string BlogContentRegex = @"<div class=""nbw-blog-start""></div>(.||\n)*<div class=""nbw-blog-end""></div>";
        public const string RealSrcRegex = @"src[^<>]+";
    }
}

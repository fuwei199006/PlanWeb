using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tool.ArticleSpider.Dtos
{
   public  class SinaBlogRegexKey
    {
        public const string UrlRegex = @"http://blog\.[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*(\.html|\.html)\?[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*";
        public const string ARegex = @"<a[^<>]+\bhref\b[^<>]+\bblog\.sina\.\b[^<>]+html\?[^<>h]+>[^<>\[\]]+</a>";//修改
        public const string BlogContentRegex = @"<!-- 正文开始 -->(.||\n)*<!-- 正文结束 -->";

        //public const string BlogImgRegex = @"<img[^<>]+src[^<>]+/>";
        public const string BlogImgRegex = @"<img[^<>]+src.+/>";
        public const string RealSrcRegex= @"src[^<>]+";
        public const string EndImgRegex = @"<img[^<>]((?!real_src).)*/>";
        public const string SrcRegex = "[^_]src[^ ]+gif\"";//
       public const string PicMsgRegex = @"\bhttp\b[^ ]+(\.jpg|\.png)";
       public const string CenterAlign = @"<p[^<>]*>.+</p>";
       public const string P = @"<p[^<>]*>";

    }
}

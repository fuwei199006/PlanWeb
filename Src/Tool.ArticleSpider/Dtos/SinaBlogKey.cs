using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.ArticleSpider.Dtos
{
   public  class SinaBlogKey
    {
        public const string UrlRegex = @"http://blog\.[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*(\.html|\.html)\?.+";
        //public const string UrlRegex = @"http://blog\.[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*(\.html|\.html)\?.+";
    }
}

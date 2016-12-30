using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tool.ArticleSpider
{
   public class SpiderSinaService
    {

        public static  string GetRealContent(string regex,string content)
        {
            return Regex.Match(regex, content).Value;
        }
    }
}

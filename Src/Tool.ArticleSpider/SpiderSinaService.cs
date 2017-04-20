
using Framework.Utility;
using Framework.Utility.Extention;
using Plain.Dto;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Framework.Utility.Utility;
using Tool.ArticleSpider.Dtos;

namespace Tool.ArticleSpider
{
    public class SpiderSinaService : BasicSpiderService
    {


        public static List<Basic_Article> GetArticles(string[] aArr, Action<string> SetLableInfo)
        {
            var articleIndex = 0;

            var articleList = new List<Basic_Article>();
            foreach (var _item in aArr)
            {

                var item = _item.ToString();
                var title = item.RemoveHtml();
                //获得Url
                var url = Regex.Match(item, SinaBlogRegexKey.UrlRegex).ToString();
                if (string.IsNullOrEmpty(url)) continue;
                var urlContent = RequestHelper.HttpGet(url);
                articleIndex++;
                //正文
                var blogContent = Regex.Match(urlContent, SinaBlogRegexKey.BlogContentRegex).Value;
                blogContent =
                    Regex.Replace(blogContent, SinaBlogRegexKey.SrcRegex, "")
                        .Replace("DIV", "p")
                        .Replace("div", "p")
                        .Replace("real_", "");
                if (!string.IsNullOrEmpty(blogContent))
                {
                    //处理正文的图片

                    #region 处理正文的图片
                    var imgUrls =
                        Regex.Matches(blogContent, SinaBlogRegexKey.BlogImgRegex)
                            .ToArray()
                            .GroupBy(r => r)
                            .Select(x => x.Key)
                            .ToArray(); //img标签
                    var imgIndex = 0;
                    foreach (var _imgUrl in imgUrls)
                    {

                        var imgUrl = RegExp.GetImgUrl(Regex.Match(_imgUrl, SinaBlogRegexKey.RealSrcRegex).Value);

                        if (!RegExp.IsPic(imgUrl) && !string.IsNullOrEmpty(imgUrl))
                        {
                            imgIndex++;
                            var fileName = articleIndex + "_" + imgIndex + "_" +
                                           Guid.NewGuid().ToString().Replace("-", "");

                            var resFilePath = RequestHelper.DownloadPicByCatergory(imgUrl, DownPath, fileName, "Sina",
                                true);
                            blogContent = blogContent.Replace(imgUrl, resFilePath);

                        }
                    }
                    #endregion


                }

                articleList.Add(new Basic_Article()
                {
                    Title = title,
                    SubTitle = blogContent.GetSubtitle(),
                    CreateTime = DateTime.Now,
                    ModifyTIme = DateTime.Now,
                    ArticleStatus = (int)ArticleStatus.Enable,
                    Author = "佚名",
                    Category = "1",
                    Content = blogContent,
                    Sort = 1,
                    SourceUrl = url,
                    Source = "Sina",
                    KeyWord = "NaN",
                    Position = "A1000"


                });
                SetLableInfo("已经抓到:" + articleIndex);
            }
            return articleList;
        }

       
    }

}

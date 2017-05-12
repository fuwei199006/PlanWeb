using Core.Service;
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
using Plain.BLL.ArticleService;
using Tool.ArticleSpider.Dtos;

namespace Tool.ArticleSpider
{
    public class BasicSpiderService
    {
        public static IArticleService _service { get { return ServiceContext.Current.CreateService<IArticleService>(); } }
        public static string DownPath
        {
            get { return Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/"); }
        }


        public static void ResizeArticle(List<Basic_Article> articleList, Action<string> SetLableInfo)
        {
            //_service.DisableUsingArticle();
            SetLableInfo("正在整理位置...");

            var configList = Config.GetConfig();
            foreach (var item in configList)
            {
                var i = 1;
                var resultList =
                    articleList.Where(
                        r =>
                            r.ArticleStatus == (int)ArticleStatus.Enable &&
                            (r.Title.ContainsCollectElement(item.keyWord) ||
                             r.SubTitle.ContainsCollectElement(item.keyWord) ||
                             r.Content.ContainsCollectElement(item.keyWord))).Take(item.count).ToList();
                resultList.ForEach(x =>
                {
                    x.Position = item.position;
                    x.ArticleStatus = 2; //代表正在被使用
                    x.Sort = i++;
                    x.KeyWord = item.keyWord;
                    TextAlignCenter(x);
                    if (item.isPic == 1)
                    {
                        //说明需要图片，获得一个图片给subtitle
                        var imgUrls =
                            Regex.Matches(x.Content, SinaBlogRegexKey.BlogImgRegex).ToArray();
                        if (imgUrls.Any())
                        {
                            x.SubTitle =
                                imgUrls.Select(r => Regex.Match(r, SinaBlogRegexKey.PicMsgRegex).Value)
                                    .FirstOrDefault(t => !string.IsNullOrEmpty(t));
                            if (string.IsNullOrEmpty(x.SubTitle))
                            {
                                x.SubTitle = "http://localhost:8088/Image/none.jpg";
                            }
                        }
                        else
                        {
                            x.SubTitle = "http://localhost:8088/Image/none.jpg";
                        }

                    }
                });
            }
            SetLableInfo("整理完成...");
        }

        public static void TextAlignCenter(Basic_Article article)
        {

            var pMarks = Regex.Matches(article.Content, SinaBlogRegexKey.CenterAlign).ToArray();
            foreach (var pMark in pMarks)
            {
                string textContent = string.Empty;
                var imgMarks = Regex.Matches(pMark, SinaBlogRegexKey.BlogImgRegex);
                if (imgMarks.Count > 0)
                {
                    var p = Regex.Match(pMark, SinaBlogRegexKey.P).Value;
                    if (!p.ToLower().Replace(" ", "").Contains("text-align:center"))
                    {

                        if (pMark.Contains("style"))
                        {
                            textContent = pMark.Replace("style=\"", "style=\"text-align:center; ")
                                .Replace("style=\'", "style=\'text-align:center; ");
                        }
                        else
                        {
                            textContent = pMark.Replace("<p", "<p style=\"text-align:center;\" ");

                        }

                    }

                }
                else
                {
                    textContent = pMark.Replace("<p", "<p style=\"text-align:center;\" ");

                }
                if (!string.IsNullOrEmpty(textContent))
                {
                    article.Content = article.Content.Replace(pMark, textContent);
                }

            }
        }
    }
}

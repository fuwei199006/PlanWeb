using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Service;
using Framework.Utility;
using Plain.BLL.Article;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Threading;
using Tool.ArticleSpider.Dtos;
using Framework.Extention;
using Plain.Dto;

namespace Tool.ArticleSpider
{
    public partial class MainFrm : Form
    {
        readonly IArticleService _service = ServiceContext.Current.CreateService<IArticleService>();
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSpider_Click(object sender, EventArgs e)
        {
            /*1. 先获得html内容
             * 2. 解析html，获得正文
             * 3. 获得正文中的img
             * 4. 下载图片，获得正确的路径
             * 5. 根据config 生成对应的文章和位置
             * */
            //下载路径


            var dataKey = DateTime.Now.ToString("yyyyMMdd") + "_Sina";
            var dataCache = GetCurrentData(dataKey);
            if (dataCache != null)
            {
                ResizeArticle(dataCache);
                SetLableInfo("正在入库");
                _service.AddArticleList(dataCache);
                SetLableInfo("完成" + dataCache.Count);
                return;
            }

            var downPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/");
            var indexHtml = RequestHelper.HttpGet("http://blog.sina.com.cn/");
            //var matchs = Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex);
            var aArr =
                Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex).ToArray().Where(r => !string.IsNullOrEmpty(r)).GroupBy(r => r).Select(x => x.Key).ToArray();
            //所有的A标签
            var articleIndex = 0;

            var articleList = new List<Basic_Article>();
            ThreadPool.QueueUserWorkItem(obj =>
            {
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

                                var resFilePath = RequestHelper.DownloadPicByCatergory(imgUrl, downPath, fileName, "Sina",
                                    true);
                                blogContent = blogContent.Replace(imgUrl, resFilePath);

                            }
                        }
                        #endregion

                        #region 处理文章尾的图片

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

                SetLableInfo("创建缓存..");
                SetCurrentData(dataKey,articleList);
                SetLableInfo("正在入库");
                ResizeArticle(articleList);
                _service.AddArticleList(articleList);
                SetLableInfo("完成" + articleList.Count);


            });

        }

        public void ResizeArticle(List<Basic_Article> articleList)
        {
            _service.DisableUsingArticle();
            SetLableInfo("正在整理位置...");
            //var dbArticleList = service.GetArticles();
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


        

        public List<Basic_Article> GetCurrentData(string key)
        {
            var cachePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../DataCache/", key + ".json");
            if (File.Exists(cachePath))
            {
                var content = File.ReadAllText(cachePath);
                return SerializationHelper.JsonDeserialize<List<Basic_Article>>(content);
            }
            return null;
        }
        public void SetCurrentData(string key, List<Basic_Article> articles)
        {
            var cachePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../DataCache/", key + ".json");
            File.WriteAllText(cachePath, SerializationHelper.JsonSerialize(articles));

        }
        #region MyRegion

        public void SetLableInfo(string info)
        {

            if (this.label1.InvokeRequired)
            {
                Action<string> action = x => label1.Text = info;
                label1.Invoke(action, info);
            }
            else
            {
                this.label1.Text = info;
            }
        }
        #endregion
        //http://blog\.[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*(\.html|\.html)\?.+
        #region 备份
        //        RequestHelper.GetCmsContent("http://blog.sina.com.cn/", c =>
        //          {
        //              var list = new List<Basic_Article>();
        //        var regex = "<a[^<>]+>[^<>]+</a>";
        //        var imgRegex = new Regex("[^_]src[^ ]+gif");

        //        var getImg = @"htt[^<>] +\.jpg";
        //        var urlRex = @"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*";
        //        var contentRex = "<!-- 正文开始 -->(.||\n)*<!-- 正文结束 -->";
        //        var matchs = Regex.Matches(c, regex);
        //        var strArr = new object[matchs.Count];
        //        matchs.CopyTo(strArr, 0);
        //              var service = ServiceContext.Current.CreateService<IArticleService>();
        //        ThreadPool.QueueUserWorkItem(obj =>
        //              {

        //                  service.DisableUsingArticle();
        //                  foreach (var o in strArr)
        //                  {
        //                      var _o = o.ToString();
        //        var urlMatchs = Regex.Match(_o, urlRex);
        //        var url = urlMatchs.Value;
        //        var tepTitle = _o.Substring(_o.IndexOf('>') + 1);
        //        var title = tepTitle.Remove(tepTitle.LastIndexOf('<'));
        //                      if (url.Contains("?"))
        //                      {

        //                          var urlContent = RequestHelper.HttpGet(url);
        //        var article = Regex.Match(urlContent, contentRex);




        //                          if (!string.IsNullOrEmpty(article.Value))
        //                          {
        //                              var content = article.Value.Replace("DIV", "p").Replace("div", "p");
        //        content = imgRegex.Replace(content, "");
        //                              content = content.Replace("real_", "");
        //                              content = TransImg(content);

        //        var articleEntity = new Basic_Article()
        //        {
        //            Content = content,
        //            Title = title,
        //            SubTitle = title,
        //            Author = "佚名",
        //            Category = "1",
        //            Source = "Sina",
        //            SourceUrl = url,
        //            Sort = 1,
        //            KeyWord = "sina",
        //            CreateTime = DateTime.Now,
        //            ModifyTIme = DateTime.Now,
        //            ArticleStatus = 1,
        //            Position = "A1000"
        //        };

        //        list.Add(articleEntity);
        //                              SetLableInfo("已经抓到" + list.Count + "条");
        //    }


        //}
        //                  }


        //                  SetLableInfo("正在整理位置...");
        //var configList = Config.GetConfig();
        //                  foreach (var item in configList)
        //                  {
        //                      var i = 1;
        //var resultList = list.Where(r => r.ArticleStatus == (int)ArticleStatus.Enable && (r.Title.ContainsCollectElement(item.keyWord) ||
        //r.SubTitle.ContainsCollectElement(item.keyWord) || r.Content.ContainsCollectElement(item.keyWord))).Take(item.count).ToList();
        //resultList.ForEach(x =>
        //                      {
        //                          x.Position = item.position;
        //                          x.ArticleStatus = 2;//代表正在被使用
        //                          x.Sort = i++;
        //                          x.KeyWord = item.keyWord;
        //                          if (item.isPic == 1)
        //                          {
        //                              //说明需要图片，获得一个图片给subtitle
        //                              var imgUrl = Regex.Match(x.Content, getImg);
        //x.SubTitle = imgUrl.Value;//
        //                          }
        //                      });

        //                  }
        //                  SetLableInfo("整理完成...");
        //                  SetLableInfo("正在入库");
        //ServiceContext.Current.CreateService<IArticleService>().AddArticleList(list);
        //                  SetLableInfo("完成" + list.Count);
        //              });





        //          }); 
        #endregion
    }
}

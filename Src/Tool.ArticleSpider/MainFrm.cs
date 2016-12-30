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
            var downPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/");
            var indexHtml = RequestHelper.HttpGet("http://blog.sina.com.cn/");
            var matchs = Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex);
            var aArr = new object[matchs.Count];//所有的A标签
            var articleIndex = 0;
            var listArticles = new List<Basic_Article>();
            foreach (var _item in aArr)
            {
                articleIndex++;
                var item = _item.ToString();
                var title = item.Substring(item.IndexOf('>') + 1);
                title = title.Remove(title.LastIndexOf('<'));//标题
                //获得Url
                var url = Regex.Match(item, SinaBlogRegexKey.UrlRegex).ToString();
                var urlContent = RequestHelper.HttpGet(url);
                //正文
                var blogContent = Regex.Match(urlContent, SinaBlogRegexKey.BlogContentRegex).Value;
                blogContent.Replace("DIV", "p").Replace("div", "p");
                if (!string.IsNullOrEmpty(blogContent))
                {
                    //处理正文的图片
                    #region 处理正文的图片
                    var imgUrls = Regex.Matches(blogContent, SinaBlogRegexKey.BlogImgRegex).ToArray();//img标签
                    var imgIndex = 0;
                    foreach (var _imgUrl in imgUrls)
                    {
                        imgIndex++;
                        var imgUrl = RegExp.GetImgUrl(_imgUrl);
                        if (!RegExp.IsPic(imgUrl))
                        {
                            var fileName = articleIndex + "_" + imgIndex + "_" + Guid.NewGuid().ToString().Replace("-", "");
                            var resFilePath = RequestHelper.DownloadPicByCatergory(imgUrl, downPath, fileName, "Sina");
                            item.Replace(imgUrl, resFilePath);
                            Regex.Replace(blogContent, SinaBlogRegexKey.SrcRegex, "");
                            blogContent.Replace("real_", "");

                        }
                    }
                    #endregion
                    #region 处理文章尾的图片

                    var endImgs = Regex.Matches(blogContent, SinaBlogRegexKey.EndImgRegex).ToArray();
                    foreach (var _endImg in endImgs)
                    {
                        imgIndex++;
                        var endImg = RegExp.GetImgUrl(_endImg);
                        var fileName = articleIndex + "_" + imgIndex + "_" + Guid.NewGuid().ToString().Replace("-", "");
                        var resFilePath = RequestHelper.DownloadPicByCatergory(endImg, downPath, fileName, "Sina");
                        item.Replace(endImg, resFilePath);
                    } 
                    #endregion
                }

                listArticles.Add(new Basic_Article()
                {
                    Title=title,
                    SubTitle=title
                });
            }


        }

        #region MyRegion
        private string TransImg(string content)
        {
            var fileDomain = "http://localhost:8088/Image/";

            var regexImg = new Regex("<img[^<>]+>");
            var regexHttp = new Regex(@"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*");
            var imgContent = regexImg.Matches(content);
            var imgUrlArr = new object[imgContent.Count];
            imgContent.CopyTo(imgUrlArr, 0);
            foreach (var itemImg in imgUrlArr)
            {


                var downPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/", DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(downPath))
                {
                    Directory.CreateDirectory(downPath);
                }
                var picName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                var fileName = downPath + "/" + picName;
                var item = regexHttp.Match(itemImg.ToString());
                if (string.IsNullOrEmpty(item.Value) || IsPic(item.Value))
                {
                    continue;
                }
                var stream = RequestHelper.HttpGetStream(item.Value);
                if (stream != null && stream != Stream.Null)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        var buffer = new byte[1024];
                        int bytesRead;
                        do
                        {
                            bytesRead = stream.Read(buffer, 0, buffer.Length);
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead > 0);

                        fileStream.Flush();
                    }
                    content = content.Replace(item.ToString(), fileDomain + "/" + DateTime.Now.ToString("yyyMMdd") + "/" + picName);
                }
            }


            return content;
        }
        private bool IsPic(string uri)
        {
            if (uri.EndsWith(".jpg") || uri.EndsWith(".jpeg") || uri.EndsWith(".bmp") || uri.EndsWith(".gif") || uri.EndsWith(".png"))
            {
                return true;
            }
            return false;
        }
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

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
            RequestHelper.GetCmsContent("http://blog.sina.com.cn/", c =>
          {
              var list = new List<Basic_Article>();
              var regex = "<a[^<>]+>[^<>]+</a>";
              var urlRex = @"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*";
              var contentRex = "<!-- 正文开始 -->(.||\n)*<!-- 正文结束 -->";
              var matchs = Regex.Matches(c, regex);
              var strArr = new object[matchs.Count];
              matchs.CopyTo(strArr, 0);
              var service = ServiceContext.Current.CreateService<IArticleService>();
              ThreadPool.QueueUserWorkItem(obj =>
              {

                  service.DisableUsingArticle();
                  foreach (var o in strArr)
                  {
                      var _o = o.ToString();
                      var urlMatchs = Regex.Match(_o, urlRex);
                      var url = urlMatchs.Value;
                      var tepTitle = _o.Substring(_o.IndexOf('>') + 1);
                      var title = tepTitle.Remove(tepTitle.LastIndexOf('<'));
                      if (url.Contains("?"))
                      {
                          var urlContent = RequestHelper.HttpGet(url);
                          var article = Regex.Match(urlContent, contentRex);

                          if (!string.IsNullOrEmpty(article.Value))
                          {
                              var content = article.Value.Replace("DIV", "p").Replace("div", "p");
                              content = regex.Replace(content, "");
                              content = content.Replace("real_", "");

                              var articleEntity = new Basic_Article()
                              {
                                  Content = content,
                                  Title = title,
                                  SubTitle = title,
                                  Author = "佚名",
                                  Category = "1",
                                  Source = "Sina",
                                  SourceUrl = url,
                                  Sort = 1,
                                  KeyWord = "sina",
                                  CreateTime = DateTime.Now,
                                  ModifyTIme = DateTime.Now,
                                  ArticleStatus = 1,
                                  Position = "A1000"
                              };

                              list.Add(articleEntity);
                              SetLableInfo("已经抓到" + list.Count + "条");
                          }


                      }
                  }


                  SetLableInfo("正在整理位置...");
                  var configList = Config.GetConfig();
                  foreach (var item in configList)
                  {
                      var resultList = list.Where(r => r.Title.ContainsCollectElement(item.keyWord) || r.SubTitle.ContainsCollectElement(item.keyWord) || r.Content.ContainsCollectElement(item.keyWord)).Take(item.count).ToList();
                      resultList.ForEach(x=>
                      {
                          x.Position = item.position;
                          x.ArticleStatus = 2;//代表正在被使用
                      });
                       
                  }
                  SetLableInfo("整理完成...");
                  SetLableInfo("正在入库");
                  ServiceContext.Current.CreateService<IArticleService>().AddArticleList(list);
                  SetLableInfo("完成" + list.Count);
              });





          });
        }

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

                var fileName = Guid.NewGuid() + ".jpg";
                var downPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download", fileName);
                var item = regexHttp.Match(itemImg.ToString());
                if (string.IsNullOrEmpty(item.Value)||IsPic(item.Value))
                {
                    continue;
                }
                var stream = RequestHelper.HttpGetStream(item.Value);
                if (stream != null && stream != Stream.Null)
                {
                    using (var fileStream = new FileStream(downPath, FileMode.Create))
                    {
                        int bytesProcessed = 0;
                        var buffer = new byte[1024];
                        int bytesRead;
                        do
                        {
                            bytesRead = stream.Read(buffer, 0, buffer.Length);
                            fileStream.Write(buffer, 0, bytesRead);
                            bytesProcessed += bytesRead;

                        }
                        while (bytesRead > 0);

                        fileStream.Flush();
                    }
                    content = content.Replace(item.ToString(), fileDomain + fileName);
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
    }
}

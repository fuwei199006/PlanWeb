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
            var content = RequestHelper.GetContent("http://blog.sina.com.cn/", c =>
            {
                var list = new List<Basic_Article>();
                var regex = "<a[^<>]+>[^<>]+</a>";
                var urlRex = @"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*";
                var contentRex = "<!-- 正文开始 -->(.||\n)*<!-- 正文结束 -->";
                var matchs = Regex.Matches(c, regex);
                var strArr = new object[matchs.Count];
                matchs.CopyTo(strArr, 0);





                ThreadPool.QueueUserWorkItem(obj =>
                {
                    foreach (var o in strArr)
                    {
                        var _o = o.ToString();
                        var urlMatchs = Regex.Match(_o, urlRex);
                        var url = urlMatchs.Value;
                        var tepTitle = _o.Substring(_o.IndexOf('>') + 1);
                        var title = tepTitle.Remove(tepTitle.LastIndexOf('<'));
                        if (url.Contains("?"))
                        {
                            var urlContent = RequestHelper.GetUrlContent(url);
                            var article = Regex.Match(urlContent, contentRex);

                            if (!string.IsNullOrEmpty(article.Value))
                            {
                                var articleEntity = new Basic_Article()
                                {
                                    Content = article.Value.Replace("DIV", "p").Replace("div", "p"),
                                    Title = title,
                                    SubTitle = title,
                                    Author = "",
                                    Category = "",
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

                    SetLableInfo("正在入库");
                    ServiceContext.Current.CreateService<IArticleService>().AddArticleList(list);
                    SetLableInfo("完成" + list.Count);
                });




                return c;
            });
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

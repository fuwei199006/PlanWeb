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
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Threading;
using Tool.ArticleSpider.Dtos;

using Plain.Dto;
using Framework.Utility.Extention;
using Framework.Utility.Utility;
using Plain.BLL.ArticleService;

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
                BasicSpiderService.ResizeArticle(dataCache, SetLableInfo);
                SetLableInfo("正在入库");
                _service.AddArticleList(dataCache);
                SetLableInfo("完成" + dataCache.Count);
                return;
            }
            //var downPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/");
            var indexHtml = RequestHelper.HttpGet("http://blog.sina.com.cn/");
            //var matchs = Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex);
            var aArr =
                Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex).ToArray().Where(r => !string.IsNullOrEmpty(r)).GroupBy(r => r).Select(x => x.Key).ToArray();
            //所有的A标签
            ThreadPool.QueueUserWorkItem(obj =>
            {

                var articleList = SpiderSinaService.GetArticles(aArr, SetLableInfo);
                SetLableInfo("创建缓存..");
                SetCurrentData(dataKey, articleList);
                SetLableInfo("正在入库");
                BasicSpiderService.ResizeArticle(articleList, SetLableInfo);
                _service.AddArticleList(articleList);
                SetLableInfo("完成" + articleList.Count);


            });
        }
        #region MyRegion
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

        private void button1_Click(object sender, EventArgs e)
        {
            var dataKey = DateTime.Now.ToString("yyyyMMdd") + "_Wangyi";
            var dataCache = GetCurrentData(dataKey);
            if (dataCache != null)
            {
                BasicSpiderService.ResizeArticle(dataCache, SetLableInfo);
                SetLableInfo("正在入库");
                _service.AddArticleList(dataCache);
                SetLableInfo("完成" + dataCache.Count);
                return;
            }
            //var downPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../Download/");
            var indexHtml = RequestHelper.HttpGet("http://blog.163.com/", Encoding.GetEncoding("GB2312"));
            //var matchs = Regex.Matches(indexHtml, SinaBlogRegexKey.ARegex);
            var aArr =
                Regex.Matches(indexHtml, WangyiBlogRegexKey.ARegex).ToArray().Where(r => !string.IsNullOrEmpty(r)).GroupBy(r => r).Select(x => x.Key).ToArray();
            //所有的A标签
            ThreadPool.QueueUserWorkItem(obj =>
            {

                var articleList = SpiderWangyiBlog.GetArticles(aArr, SetLableInfo);
                SetLableInfo("创建缓存..");
                SetCurrentData(dataKey, articleList);
                SetLableInfo("正在入库");
                BasicSpiderService.ResizeArticle(articleList, SetLableInfo);
                _service.AddArticleList(articleList);
                SetLableInfo("完成" + articleList.Count);


            });
        }
    }
}

using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plain.BLL.Article;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Framework.Utility.Utility;

namespace Plain.BLL.Article.Tests
{
    [TestClass()]
    public class ArticleServiceTests
    {
        [TestMethod()]
        public void UpdateArticleTest()
        {
            var service = new ArticleService();
            var list = service.GetArticles().Where(r=>r.Id== 51).ToList();
            var regex = new Regex("[^_]src[^ ]+");
            foreach (var item in list)
            {
                item.Content = regex.Replace(item.Content, "");
                item.Content =  item.Content.Replace("real_", "");
                item.Content = TransImg(item.Content);
            }

            service.UpdateRang(list);
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
                if (string.IsNullOrEmpty(item.Value))
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

                  content= content.Replace(item.ToString(), fileDomain + fileName);
                }
            }
        

            return content;
        }

        [TestMethod()]
        public void FixImgArticleTest()
        {
            var service = new ArticleService();
            var list = service.GetArticles().Where(r => r.SubTitle == string.Empty).ToList();
            var regex = @"htt[^<>]+\.jpg";
            foreach (var item in list)
            {
                //说明需要图片，获得一个图片给subtitle
                var imgUrl = Regex.Match(item.Content, regex);
                item.SubTitle = imgUrl.Value;//
            }

            service.UpdateRang(list);
        }

    }
}
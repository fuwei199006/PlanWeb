using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool.ArticleSpider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Framework.Utility;
using System.Net;
using Plain.BLL.Article;

namespace Tool.ArticleSpider.Tests
{
    [TestClass()]
    public class MainFrmTests
    {
        [TestMethod()]
        public void MainFrmTest()
        {

            var content = "<img style=\"MArGin: 0pt auto; WiDTH: 332px; DispLAY: block; HeiGHT: 442px\" name=\"image_operate_7781482760236102\" src=\"http://s16.sinaimg.cn/mw690/001x4W9Mzy77uTc8pOf2f&amp;690\" real_src=\"http://s16.sinaimg.cn/mw690/001x4W9Mzy77uTc8pOf2f&amp;690\" width=\"329\" height=\"524\" alt=\"吃鱼不见鱼，吃肉不见肉的“蒸鱼糕”\" title=\"吃鱼不见鱼，吃肉不见肉的“蒸鱼糕”\">";
            var fileName = Guid.NewGuid() + ".jpg";
            //var fileDomain = "http://localhost:8088/Image/";
            var downPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Download", fileName);
            var regexImg = new Regex("<img[^<>]+>");
            var regexHttp = new Regex(@"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*");
            var imgContent = regexImg.Match(content);
            var item = regexHttp.Match(imgContent.Value);



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

                
            }
        }

        public Stream GetContent(string url)
        {
            string strLine = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
            request.Method = "GET";
            //request.Referer = "http://blog.sina.com.cn";
            //request.ContentType = "image/jpeg";
            //request.Host = "s1.sinaimg.cn";


            var response = request.GetResponse() ;
            var stream = response.GetResponseStream();
          
            return stream;
        }
              [TestMethod()]
        public void UpdateArticleTest()
        {
            var service = new ArticleService();
            var list = service.GetArticles().Where(r=>r.Id== 1).ToList();
            var regex = @"(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*";
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
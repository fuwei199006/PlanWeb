using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Framework.Utility;
using System.Threading;

namespace Framework.Utility
{
    /// <summary>
    /// 向远程Url Post/Get数据类
    /// </summary>
    public class RequestHelper
    {

        private const string DomainUrl = "http://localhost:8088/Image/";
        #region HttpPost
        public static T HttpPost<T>(string uri, object data, SerializationType serializationType)
        {
            string responseText = HttpPost(uri, data, serializationType);

            T t = default(T);
            if (serializationType == SerializationType.Xml)
            {
                t = (T)SerializationHelper.XmlDeserialize(typeof(T), responseText);
            }
            else if (serializationType == SerializationType.Json)
            {
                t = SerializationHelper.JsonDeserialize<T>(responseText);
            }
            return t;
        }

        public static string HttpPost(string uri, object data, SerializationType serializationType)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            string dataStr = string.Empty;
            if (data is string)
            {
                dataStr = (string)data;
            }
            else
            {
                if (serializationType == SerializationType.Xml)
                {
                    dataStr = SerializationHelper.XmlSerialize(data);
                    object o = SerializationHelper.XmlDeserialize(data.GetType(), dataStr);
                }
                else if (serializationType == SerializationType.Json)
                {
                    dataStr = SerializationHelper.SerializeObject(data);
                }
            }
            CNNWebClient wc = new CNNWebClient();
            wc.Timeout = 300;
            var t = wc.UploadData(uri, "POST", Encoding.UTF8.GetBytes(dataStr));
            string tText = Encoding.UTF8.GetString(t);

            return tText;
        }

        public static string HttpPost(string uri, System.Collections.Specialized.NameValueCollection data)
        {
            CNNWebClient wc = new CNNWebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Timeout = 300;
            var t = wc.UploadValues(uri, "POST", data);
            string tText = Encoding.UTF8.GetString(t);
            return tText;
        }
        #endregion


        public static T HttpGet<T>(string uri, SerializationType serializationType)
        {
            string responseText = HttpGet(uri);

            T t = default(T);
            if (serializationType == SerializationType.Xml)
            {
                t = (T)SerializationHelper.XmlDeserialize(typeof(T), responseText);
            }
            else if (serializationType == SerializationType.Json)
            {
                t = SerializationHelper.JsonDeserialize<T>(responseText);
            }
            return t;
        }

        /// <summary>
        /// 获得html的内容
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="retry">重试次数,默认重试3次</param>
        /// <returns></returns>
        public static string HttpGet(string uri, int retry = 3)
        {
            if (retry == 0) return string.Empty;
            try
            {
                StringBuilder respBody = new StringBuilder();
                HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                byte[] buffer = new byte[8192];
                Stream stream;
                stream = response.GetResponseStream();
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, buffer.Length);
                    if (count != 0)
                        respBody.Append(Encoding.UTF8.GetString(buffer, 0, count));
                }
                while (count > 0);
                string responseText = respBody.ToString();
                return responseText;
            }
            catch (WebException exp)
            {
                Thread.Sleep(60 * 1000);
                return HttpGet(uri, --retry);

            }

        }
        /// <summary>
        /// 获得文件流
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="retry"></param>
        /// <returns></returns>
        public static Stream HttpGetStream(string uri, int retry = 3)
        {
            if (retry == 0||string.IsNullOrEmpty(uri)) return null;
            StringBuilder respBody = new StringBuilder();
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                byte[] buffer = new byte[8192];
                Stream stream;
                stream = response.GetResponseStream();
                return stream;
            }
            catch (WebException e)
            {
                Thread.Sleep(60 * 1000);
                return HttpGetStream(uri, --retry);
            }

        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="extention"></param>
        /// <param name="catergory">类别名称</param>
        /// <returns></returns>
        public static bool DownloadPic(string url, string path, string name, string extention = ".jpg")
        {
            if (!name.Contains("."))
            {
                name = name + extention;
            }
            var stream = HttpGetStream(url);
            if (stream != null && stream != Stream.Null)
            {
                using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
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
                return true;
            }

            return false;
        }

        public static string  DownloadPicByCatergory(string url,string path,string name,string catergory, string extention = ".jpg")
        {
            return DownloadPicByCatergory(url, path, name, catergory, false, extention);
        }

        public static string DownloadPicByCatergory(string url, string path, string name, string catergory, bool isReturnDomainPath, string extention = ".jpg")
        {
            
            var datePath = Path.Combine(DateTime.Now.ToString("yyyyMMdd"), catergory);
            var pythicalPath = Path.Combine(path, datePath);
            if (!Directory.Exists(pythicalPath))
            {
                Directory.CreateDirectory(pythicalPath);
            }
            var res = DownloadPic(url, pythicalPath, name, extention);
            if (res)
            {
                if (isReturnDomainPath)
                {
                    return DomainUrl + Path.Combine(datePath, name).Replace(@"\","/")+extention;
                }
                return Path.Combine(datePath, name) + extention;
            }
            return string.Empty;
        }


        public static void GetCmsContent(string url, Action<string> action)
        {

            var content = HttpGet(url);
            action(content);
        }
        public class CNNWebClient : WebClient
        {

            private int _timeOut = 200;

            /// <summary>
            /// 过期时间
            /// </summary>
            public int Timeout
            {
                get
                {
                    return _timeOut;
                }
                set
                {
                    if (value <= 0)
                        _timeOut = 200;
                    _timeOut = value;
                }
            }

            /// <summary>
            /// 重写GetWebRequest,添加WebRequest对象超时时间
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.Timeout = 1000 * Timeout;
                request.ReadWriteTimeout = 1000 * Timeout;
                return request;
            }
        }
    }
}

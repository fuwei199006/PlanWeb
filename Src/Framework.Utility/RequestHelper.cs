using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Framework.Utility;


namespace Framework.Utility
{
    /// <summary>
    /// 向远程Url Post/Get数据类
    /// </summary>
    public class RequestHelper
    {
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

        public static string HttpGet(string uri)
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

        public static Stream HttpGetStream(string uri)
        {
            StringBuilder respBody = new StringBuilder();
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            byte[] buffer = new byte[8192];
            Stream stream;
            stream = response.GetResponseStream();
            return stream;
        }

        public static Stream HttpGetStream(string uri,Dictionary<string,string> headers)
        {
            StringBuilder respBody = new StringBuilder();
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            //request.Referer = "http://blog.sina.com.cn/s/blog_4fe4dc6f0102xg82.html?tj=1";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            byte[] buffer = new byte[8192];
            Stream stream;
            stream = response.GetResponseStream();
            return stream;
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

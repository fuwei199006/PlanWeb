using System;
using System.IO;
using System.Text;

namespace Tools.Server
{
    public class HttpRequest
    {
        public HttpRequest(string request)
        {
            string[] requestLines = request.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            this.RequestMethod = requestLines[0].Split(' ')[0];
            RequestUrl = Untility.UrlDeCode(requestLines[0].Split(' ')[1],UTF8Encoding.UTF8);
            if (RequestUrl.Contains("?"))
            {
                RequestUrl= RequestUrl.Split('?')[0];
            }

            this.FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + RequestUrl);
            var ext = Path.GetExtension(FilePath);
            if (string.IsNullOrEmpty(ext))
            {
                var methodArr = this.RequestUrl.Split('/');
                if (methodArr.Length > 1)
                    this.RequestClass = this.RequestUrl.Split('/')[1];
                if (methodArr.Length > 2)
                    this.Method = this.RequestUrl.Split('/')[2];
            }

        }

        public string RequestUrl { get; set; }
        public string FilePath { get; set; }

        public string RequestMethod { get; set; }
        public string Method { get; set; }

        private string _requestClass;
        public string RequestClass
        {
            get { return _requestClass + "Controller"; }
            set { _requestClass = value; }
        }

        public string ContentType { get; set; }



    }
}
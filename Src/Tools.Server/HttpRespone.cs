using System;
using System.Text;

namespace Tools.Server
{
    public class HttpRespone
    {
        public byte[] Body { get; internal set; }
        public string ContetType { get; internal set; }
        public byte[] Header
        {
            get { return GetHeader(); }

        }

        public byte[] GetHeader()//这里对数据不作太多的处理
        {
            var sb = new StringBuilder();
            sb.AppendLine("HTTP/1.1 {0}");
            sb.AppendLine("Date:" + DateTime.Now);
            sb.AppendLine("Content-Type:" + "{1}");
            sb.AppendLine("Content-Length:" + "{2}");
            sb.AppendLine();//很重要
            var header = string.Format(sb.ToString(), StatusCode, ContetType, Body.Length);
            return Encoding.Default.GetBytes(header);
        }
        public string StatusCode { get; internal set; }
    }
}
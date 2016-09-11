using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Core.Exception;
using Frameworke.Dtos;
using Newtonsoft.Json;

namespace Framework.Utility
{
    public class RequestHelper
    {
        public static DeviceDto GetDeviceDto(string userAgent)
        {
            var url = "http://www.useragentstring.com/";
            url += "?uas=" + userAgent;
            url += "&getJSON=all";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream != null && stream != Stream.Null)
            {
                var streamReader = new StreamReader(stream, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                string strLine;
                while ((strLine = streamReader.ReadLine()) != null)
                {
                    sb.Append(strLine);
                }

                return JsonConvert.DeserializeObject<DeviceDto>(sb.ToString());
            }
            return new DeviceDto();

        }

        public static string GetDeviceJson(string userAgent)
        {
            try
            {
                var url = "http://www.useragentstring.com/";
                url += "?uas=" + userAgent;
                url += "&getJSON=all";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 1;
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null && stream != Stream.Null)
                {
                    var streamReader = new StreamReader(stream, Encoding.UTF8);
                    StringBuilder sb = new StringBuilder();
                    string strLine;
                    while ((strLine = streamReader.ReadLine()) != null)
                    {
                        sb.Append(strLine);
                    }

                    var result = JsonConvert.DeserializeObject<DeviceDto>(sb.ToString());
                    return string.Concat(result.os_type, ":", result.os_name, "/", result.agent_type, ":", result.agent_name,
                        " ", result.agent_version);
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return userAgent;

            }


        }


        public static string GetContent(string url)
        {
            return GetContent(url, 0, 1, Encoding.UTF8);
        }
        public static string GetContent(string url, int timeOut, int reTry)
        {
            return GetContent(url, timeOut, reTry, Encoding.UTF8);
        }

        public static string GetContent(string url, Func<string, string> filter)
        {
            var content = GetContent(url, 0, 3);
            if (filter != null)
            {
                return filter(content);
            }
            return content;
        }

        public static string GetContent(string url, int timeOut, int reTry, Encoding encoding)
        {
            while (reTry > 0)
            {

                try
                {

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    if (timeOut != 0) request.Timeout = timeOut;
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    if (stream != null && stream != Stream.Null)
                    {
                        var streamReader = new StreamReader(stream, Encoding.UTF8);
                        StringBuilder sb = new StringBuilder();
                        string strLine;
                        while ((strLine = streamReader.ReadLine()) != null)
                        {
                            sb.Append(strLine);
                        }


                        return sb.ToString();

                    }

                }

                catch (WebException)
                {

                }
                finally
                {
                    reTry--;
                }

            }
            throw new OverRetryException("已经超过了最大的重试次数");
        }

        public static string GetUrlContent(string url)
        {

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null && stream != Stream.Null)
                {
                    var streamReader = new StreamReader(stream, Encoding.UTF8);
                    StringBuilder sb = new StringBuilder();
                    string strLine;
                    while ((strLine = streamReader.ReadLine()) != null)
                    {
                        sb.Append(strLine);
                    }


                    return sb.ToString();

                }
                return String.Empty;
            }
            catch 
            {
                return String.Empty;
            }
          


        }
    }
}
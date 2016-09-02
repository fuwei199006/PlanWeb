using System;
using System.IO;
using System.Net;
using System.Text;
using Frameworke.Dtos;
using Newtonsoft.Json;

namespace Framework.Utility
{
    public class RequestHelper
    {
        public static DeviceDto GetDeviceDto(string userAgent)
        {
            var url ="http://www.useragentstring.com/";
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
    }
}
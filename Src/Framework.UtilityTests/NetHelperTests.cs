using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.Model.Models.Model;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Framework.Utility.Tests
{
    [TestClass()]
    public class NetHelperTests
    {
        [TestMethod()]
        public void HttpPostTest()
        {
            //var token = "CE1C831C-38E3-463D-82CC-0FF13F461707";
            //var url = "http://localhost:8080/";

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //// Add an Accept header for JSON format.
            //// 为JSON格式添加一个Accept报头
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.ReadAsAsync("PlainApi/LoginApi/GetLoginInfoByToken",new { }).Result;


            //if (response.IsSuccessStatusCode)
            //{
            //    var products = response.Content.ReadAsAsync<IEnumerable<ProductInfo>>().Result;
            //}
           
            //var res = SerializationHelper.JsonDeserialize<Basic_LoginInfo>(response.Content.ToString());
            //Assert.AreEqual(res.LoginName, "admin@qq.com");
        }



    }
}
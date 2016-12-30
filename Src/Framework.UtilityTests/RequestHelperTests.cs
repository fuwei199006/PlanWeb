using System;
using System.Text;
using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.IO;

namespace Framework.Utility.Tests
{
    [TestClass()]
    public class RequestHelperTests
    {
        [TestMethod()]
        public void GetContentTest()
        {
            //var result =
            //    RequestHelper.GetContent("https://www.baidu.com/", 0,3,Encoding.UTF8);
            //Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DownloadPicByCatergoryTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download");
            var name = Guid.NewGuid().ToString().Replace("-", "");
            RequestHelper.DownloadPicByCatergory("http://n.sinaimg.cn/blog/20161230/YFDn-fxzencv2447378.jpg", path, name, "sina");
            Assert.IsTrue(File.Exists(path + "/sina/" + name + ".jpg"));
        }

        //[TestMethod()]
        //public void HttpPostTest()
        //{
          
        //    RequestHelper.UploadFile("http://localhost:8088/Image/", @"E:\github\PlanWeb\Src\Framework.UtilityTests\bin\Debug\Download\20161230\sina\b0d02f30af774d93947bb81e0152e192.jpg");
        //}
    }
}

namespace Framework.UtilityTests
{
    [TestClass()]
    public class GetDeviceDtoTests
    {

        [TestMethod]
        public void GetStr()
        {
            var sql = @"Mozilla / 5.0(Windows NT 6.1; WOW64) AppleWebKit / \r\n\r\r\r\r\t\r\r537.36(KHTML, like Gecko) Chrome / 53.0.2785.30 Safari / 537.36";
            var res = StringUtil.DeleteUnVisibleChar(sql);
            var html = HttpUtility.UrlDecode(sql);
        }
        [TestMethod()]
        public void GetDeviceDtoTest()
        {

            //var result =
            //    RequestHelper.GetDeviceJson(
            //        "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.30 Safari/537.36");

            //Assert.AreEqual(String.IsNullOrEmpty(result ),false );
        }
    }
}
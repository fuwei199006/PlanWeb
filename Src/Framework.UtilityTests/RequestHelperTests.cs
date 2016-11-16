using System;
using System.Text;
using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;

namespace Framework.Utility.Tests
{
    [TestClass()]
    public class RequestHelperTests
    {
        [TestMethod()]
        public void GetContentTest()
        {
            var result =
                RequestHelper.GetContent("https://www.baidu.com/", 0,3,Encoding.UTF8);
            Assert.IsNotNull(result);
        }
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

            var result =
                RequestHelper.GetDeviceJson(
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.30 Safari/537.36");

            Assert.AreEqual(String.IsNullOrEmpty(result ),false );
        }
    }
}
using System;
using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.UtilityTests
{
    [TestClass()]
    public class GetDeviceDtoTests
    {
        [TestMethod()]
        public void GetDeviceDtoTest()
        {

            var result =
                RequestHelper.GetDeviceDto(
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.30 Safari/537.36");

            Assert.AreEqual(String.IsNullOrEmpty(result.os_name),false );
        }
    }
}
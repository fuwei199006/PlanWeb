using System;
using Core.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.ConfigTests
{
    [TestClass()]
    public class ConfigContextTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var str= LocalCachedConfigContext.Current.DaoConfig;
            var str1= LocalCachedConfigContext.Current.DaoConfig;
            Assert.AreEqual(str,str1);
        }
    }
}
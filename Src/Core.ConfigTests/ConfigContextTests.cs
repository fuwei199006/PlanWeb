using System;
using Core.Cache;
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

        [TestMethod()]
        public void GetConfigTest()
        {
            var str = LocalCachedConfigContext.Current.CacheConfig;
            var str1 = LocalCachedConfigContext.Current.CacheConfig;
            Assert.AreEqual(str, str1);
        }

        [TestMethod()]
        public void GetCacheTest()
        {
            CacheContext.Set("name","qweqweq");
            CacheContext.Set("name1","qweqweq1");
            CacheContext.Set("name2","qweqweq2");
            CacheContext.Set("name3","qweqweq3");
            CacheContext.Set("name4","qweqweq4");
            Assert.AreEqual(CacheContext.Get("name"), "qweqweq");
            Assert.AreEqual(CacheContext.Get("name1"), "qweqweq1");
            Assert.AreEqual(CacheContext.Get("name2"), "qweqweq2");
            Assert.AreEqual(CacheContext.Get("name3"), "qweqweq3");
            Assert.AreEqual(CacheContext.Get("name4"), "qweqweq4");

        }
    }
}
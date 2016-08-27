using System;
using Core.Cache;
using Core.Config;
using Core.Config.ConfigModel;
using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.ConfigTests
{
    [TestClass()]
    public class ConfigContextTests
    {
        [TestMethod()]
        public void GetDaoConfigTest()
        {
            var str= LocalCachedConfigContext.Current.DaoConfig;
            var str1= LocalCachedConfigContext.Current.DaoConfig;
            Assert.AreEqual(str,str1);
        }

        [TestMethod()]
        public void GetCacheConfigTest()
        {
            var str = LocalCachedConfigContext.Current.CacheConfig;
            var str1 = LocalCachedConfigContext.Current.CacheConfig;
            Assert.AreEqual(str, str1);
        }

        [TestMethod()]
        public void GetSettingConfigTest()
        {
            var str = LocalCachedConfigContext.Current.SettingConfig;
            var str1 = LocalCachedConfigContext.Current.SettingConfig;
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

        [TestMethod]
        public void SaveConfigTest()
        {
            var daoConfig=new DaoConfig()
            {
                BaseDao = "ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=",
                BussinessDaoConfig = "ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=",
                CreateTime = DateTime.Now,
                Log = "ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSU+AC9GHwuYgT3PnAnt3YAQ=",
                Id = 1
            };
            var xml = SerializationHelper.XmlSerialize(daoConfig);
            ConfigContext ct=new ConfigContext();
            ct.Save("Dao-DaoConfig",xml);
        }
    }
}
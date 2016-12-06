using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plain.Model.Models.Model;

namespace Core.Cache.Tests
{
    [TestClass()]
    public class MemcacheProviderTests
    {
        [TestMethod()]
        public void GetMemcacheProviderTest()
        {
            var cachedProvider = new MemcacheProvider();

            cachedProvider.Set("key001", "myName");
            cachedProvider.Set("key002", "myName", 1);
            var key1 = cachedProvider.Get("key001");
            var key2 = cachedProvider.Get("key002");
            Assert.AreEqual(key1, "myName");
            Assert.AreEqual(key2, "myName");
            cachedProvider.Remove("key001");
            var key3 = cachedProvider.Get("key001");
            Assert.AreEqual(key3, null);
            Thread.Sleep(60 * 1000);
            var key4 = cachedProvider.Get("key002");
            Assert.AreEqual(key4, null);
        }


        [TestMethod()]
        public void GetMemcacheProviderObjTest()
        {
            var cachedProvider = new MemcacheProvider();

            cachedProvider.Set("key001", new Basic_UserInfo()
            {
                LoginName = "fuwei",
                NickName = "dahai",
                RealName = "fuwei"
            });
 
            var key1 = cachedProvider.Get("key001") as Basic_UserInfo;

            //todo:必须所有的要使用 [Serializable]标签
            Assert.AreEqual(key1.LoginName, "fuwei");
 
 
   
        }
    }


}
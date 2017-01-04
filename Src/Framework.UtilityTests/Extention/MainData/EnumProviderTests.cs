using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Utility.Extention.MainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.Dto;

namespace Framework.Utility.Extention.MainData.Tests
{
    [TestClass()]
    public class EnumProviderTests
    {
        [TestMethod()]
        public void GetStrValueEntityDictionaryTest()
        {
            var dic = new EnumProvider().GetStrValueEntityDictionary<PowerGroup>();

        }

        [TestMethod()]
        public void GetItemAttributeListTest()
        {
            Assert.AreEqual(PowerGroup.SystemPower.ToInt(), 1);
        }

        [TestMethod()]
        public void GetStrValueDescDictionaryTest()
        {
            var dic = new EnumProvider().GetStrValueDescDictionary<PowerGroup>();
            Assert.AreEqual(dic["SystemPower"], "系统权限");
        }

        [TestMethod()]
        public void GetIntValueDescDictionaryTest()
        {
            var dic = new EnumProvider().GetIntValueDescDictionary<PowerGroup>();
            Assert.AreEqual(dic[1], "系统权限");
        }

        [TestMethod()]
        public void GetIntValueEntityDictionaryTest()
        {
            var dic = new EnumProvider().GetIntValueEntityDictionary<PowerGroup>();
            Assert.AreEqual(dic[1].Title, "系统权限");
        }

        [TestMethod()]
        public void GetStrValueEntityDictionaryTest1()
        {
            var dic = new EnumProvider().GetStrValueEntityDictionary<PowerGroup>();
            Assert.AreEqual(dic["SystemPower"].Title, "系统权限");
        }

        [TestMethod()]
        public void GetDictionaryTest()
        {
            var dic = new EnumProvider().GetDictionary<PowerGroup>();
            Assert.AreEqual(dic[PowerGroup.SystemPower].Title, "系统权限");
        }

        [TestMethod()]
        public void GetEntityByValueTest()
        {
            var res = new EnumProvider().GetEntityByValue<PowerGroup>(1);
            Assert.AreEqual(res.Title, "系统权限");
        }

        [TestMethod()]
        public void GetDescByValueTest()
        {
            var res = new EnumProvider().GetDescByValue<PowerGroup>(1);
            Assert.AreEqual(res, "系统权限");
        }

        [TestMethod()]
        public void GetDescByFiledTest()
        {
            var res = new EnumProvider().GetDescByFiled<PowerGroup>("SystemPower");
            Assert.AreEqual(res, "系统权限");
        }

        [TestMethod()]
        public void GetEntityByFiledTest()
        {
            var res = new EnumProvider().GetEntityByFiled<PowerGroup>("SystemPower");
            Assert.AreEqual(res.Title, "系统权限");
        }
    }
}
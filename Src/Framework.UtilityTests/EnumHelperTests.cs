using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Utility.ValideCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Extention;
using Plain.Dto;

 
namespace Framework.Utility.ValideCode.Tests
{
    [TestClass()]
    public class EnumHelperTests
    {
        [TestMethod()]
        public void GetItemAttributeListTest()
        {
            var res = EnumHelper.GetItemList<MenuType>();
        }
        [TestMethod()]
        public void ParseTest()
        {
            var res = "Nav".EnumTryParse<MenuType>();
            Assert.AreEqual(res,MenuType.Nav);
        }
        [TestMethod()]
        public void GetEnumTitleTest()
        {
            var res = MenuType.Function.GetEnumTitle();
            Assert.AreEqual(res, "功能");
        }
        [TestMethod()]
        public void GetItemValueListTest()
        {
            var res = EnumHelper.GetItemValueList<MenuType>();
        }
    }
}
using Framework.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Utility.ValideCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var res = EnumHelper.Parse<MenuType>("Nav");
            Assert.AreEqual(res,MenuType.Nav);
        }
        [TestMethod()]
        public void GetItemValueListTest()
        {
            var res = EnumHelper.GetItemValueList<MenuType>();
        }
    }
}
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
    }
}
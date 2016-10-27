using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plain.BLL.MenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.Dto;

namespace Plain.BLL.MenuService.Tests
{
    [TestClass()]
    public class MenuServiceTests
    {
        [TestMethod()]
        public void GetMenuDtoTest()
        {
            var menservice = new MenuService();
            var res = menservice.GetMenuDtos("人员管理", 1,100).FirstOrDefault();

            Assert.AreEqual(res.MenuIcon, "icon-user");

        }
    }
}
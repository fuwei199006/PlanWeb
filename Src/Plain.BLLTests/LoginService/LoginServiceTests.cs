using System;
using System.Reflection;
using Framework.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plain.BLL;
using Plain.BLL.LoginService;
using Plain.Model.Models;

namespace Plain.BLLTests.LoginService
{
    [TestClass()]
    public class LoginServiceTests
    {
        [TestMethod()]
        public void AddLoginInfo()
        {

            ILoginService loginService = new BLL.LoginService.LoginService();
           var entity= loginService.AddLoginInfo(new Basic_LoginInfo()
            {
                LoginName = "fuwei",
                LoginUserId = 0,
                LoginTime = DateTime.Now,
                ExpireTime = DateTime.Now.AddHours(1),
                LoginStatus = 1,
                LoginType = 1,
                LoginIp = "127.0.0.1",
                LoginHeader = "123",
                IsDelete = false,
                LastUpdateTime = DateTime.Now,
                LoginToken = Guid.NewGuid(),
                CreateTime = DateTime.Now
            });

            Assert.AreNotEqual(entity,null);
        }

        [TestMethod]
        public void TestAutofac()
        {
            var obje =
                typeof (BaseService<>).IsAssignableFrom(typeof (BaseService<>).GetInterface(typeof (IBaseService<>).Name));
        }
    }
}

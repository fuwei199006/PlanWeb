using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                LoginTime = DateTime.Now,
                ExpireTime = DateTime.Now,
                LogStatus = 1,
                LogType = 1,
                LoginIp = "127.0.0.1",
                LoginHeader = "123",
                IsDelete = false,
                LastUpdateTime = DateTime.Now,
                LoginToken = Guid.NewGuid()
            });

            Assert.AreNotEqual(entity,null);
        }
    }
}

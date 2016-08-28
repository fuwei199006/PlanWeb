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
           var entity= loginService.Add(new Basic_LoginInfo()
            {
                LoginName = "fuwei",
                LoginTime = DateTime.Now,
                ExpireTime = DateTime.Now,
                LoginIp = "127.0.0.1",
                LoginHeader = "123",
                IsDelete = true,
                LastUpdateTime = DateTime.Now,
                LoginToken = Guid.NewGuid().ToString()
            });

            Assert.AreNotEqual(entity,null);
        }
    }
}

﻿using System;
using System.Reflection;
using System.Threading;
using Framework.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plain.BLL;
using Plain.BLL.LoginService;
using Plain.Model.Models;
using Plain.Model.Models.Model;
namespace Plain.BLL.LoginService.Tests
{
    [TestClass()]
    public class LoginServiceTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            ILoginService loginService = new BLL.LoginService.LoginService();
            while (true)
            {
                ThreadPool.QueueUserWorkItem(r =>
                {
                    loginService.LoginTest("yunwei@163.com", "111111");
                });

            }



        }
    }
}

namespace Plain.BLLTests.LoginService
{
    [TestClass()]
    public class LoginServiceTests
    {
        [TestMethod()]
        public void AddLoginInfo()
        {

            ILoginService loginService = new BLL.LoginService.LoginService();
            var entity = loginService.AddLoginInfo(new Basic_LoginInfo()
            {
                LoginName = "756091180@qq.com",
                LoginUserId = 0,
                LoginNickName = "大海",
                LoginTime = DateTime.Now,
                ExpireTime = DateTime.Now.AddHours(1),
                LoginStatus = 1,
                LoginType = 1,
                LoginIp = "127.0.0.1",
                //LoginHeader = "123",
                IsDelete = false,
                LastUpdateTime = DateTime.Now,
                LoginToken = Guid.NewGuid(),
                CreateTime = DateTime.Now
            });

            Assert.AreNotEqual(entity, null);
        }

        [TestMethod]
        public void TestAutofac()
        {
            var obje =
                typeof(BaseService<>).IsAssignableFrom(typeof(BaseService<>).GetInterface(typeof(IBaseService<>).Name));
        }


        [TestMethod()]
        public void LogintOut()
        {
            ILoginService loginService = new BLL.LoginService.LoginService();

            var res = loginService.LoginOut(new Guid("CF107749-65CD-4F67-94FD-877C88A106C1"));

            Assert.AreEqual(res, true);

        }

        [TestMethod()]
        public void LogintTest()
        {
            ILoginService loginService = new BLL.LoginService.LoginService();
            while (true)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(r =>
                    {

                        var res = loginService.GetLoginInfoByToken(new Guid("C1EA4C21-B049-4323-A010-6CA8273B4D6D"));
                        Assert.AreEqual(res.LoginToken, "C1EA4C21-B049-4323-A010-6CA8273B4D6D");

                    });
                }
                catch (Exception)
                {

                    break;
                }

            }


        }
    }
}

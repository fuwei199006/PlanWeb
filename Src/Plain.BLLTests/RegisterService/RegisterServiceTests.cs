using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plain.BLL.RegisterService;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Encrypt;
using Framework.Utility;
using Plain.Model.Models;

namespace Plain.BLL.RegisterService.Tests
{
    [TestClass()]
    public class RegisterServiceTests
    {
        [TestMethod()]
        public void AddRegisterTest()
        {
            var registerService=new RegisterService();
            var register = new Basic_Register()
            {
                RegisterName = "123",
                RegisterPassword = MD5Encrypt.Md5("12345678"),
                RegisterConfirmPassword = MD5Encrypt.Md5("12345678"),
                RegisterEmail = "QQ@QQ.com",
                RegisterPhone = "10000000000",//表示无手机号
                RegisterTime = DateTime.Now,
                RegisterDevice = "asdfasdfasddddddddddddddddddddddddddddddd",
                RegisterStatus = true,
                RetisterIp = "127.0.0.1",
                Expiretime = DateTime.Now.AddDays(7),
                CreateTime = DateTime.Now
            };
            
            try
            {
                var res = registerService.AddRegister(register);
                Assert.AreEqual(res != null, true);
            }
            catch (DbEntityValidationException e)
            {
                
                Assert.Fail();
            }
         
           
        }
    }
}
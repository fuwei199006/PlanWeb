using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Encrypt.Tests
{
    [TestClass()]
    public class RSAEncryptTests
    {
        [TestMethod()]
        public void RSAKeyTest()
        {
            var strKey = string.Empty;
            var strPublicKey = string.Empty;
            RSAEncrypt.GetRSAKey(out strKey,out  strPublicKey);
            var str = "1234567890";
            var keyStr = RSAEncrypt.Encrypt(strPublicKey, str);
            var dKeyStr = RSAEncrypt.Decrypt(strKey, keyStr);

            Assert.AreEqual(str,dKeyStr);
        }
    }
}
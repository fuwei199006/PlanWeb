using Core.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.MessageTests
{
    [TestClass()]
    public class MailContextTests
    {
        [TestMethod()]
        public void SendEmailTest()
        {
           var res= MailContext.SendEmail("756091180@qq.com","测试","<h1>测试Plain的信息发送功能</h1>");

            Assert.AreEqual(res,true);
        }
    }
}
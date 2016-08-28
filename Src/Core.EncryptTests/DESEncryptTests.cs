using Core.Encrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.EncryptTests
{
    [TestClass()]
    public class DESEncryptTests
    {
        [TestMethod()]
        public void DecodeTest()
        {
            var str = DESEncrypt.Decode("MSfDf7tgpMAqN/MQTjHRfEwS4LW07Aut4rINOrEc00JXSPfPghUvPe0rIbrrMCPkeqcZHTDQuCLXquFc0TGMbQ==");
          
        }

        [TestMethod()]

        public void EncodeTest()
        {
            var str = DESEncrypt.Encode("server=.;database=PlanDb;user id=sa;password=Abc12345");

        }
    }
}

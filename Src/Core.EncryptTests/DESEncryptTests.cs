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
            var str = DESEncrypt.Decode("ufj0QNXJls94JUY/drjBvSNj8EP72p+FT4KmwagfHXLXbgRRWGLCNliIueckrK9VNme0UM93vgHFPM6UOXRphA==");
          
        }

        [TestMethod()]

        public void EncodeTest()
        {
            var str = DESEncrypt.Encode("server=.;database=PlanDb;user id=sa;password=Abc12345");

        }
    }
}

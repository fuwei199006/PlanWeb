using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Log.Tests
{
    [TestClass()]
    public class Log4NetHelperTests
    {
        [TestMethod()]
        public void DebugTest()
        {
             
          Log4NetHelper.Info(LoggerType.ServiceExceptionLog, "123", new Exception("qweqwe"));

        }
    }
}
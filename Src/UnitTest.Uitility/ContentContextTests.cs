using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tools.Server.Tests
{
    [TestClass()]
    public class ContentContextTests
    {
        [TestMethod()]
        public void GetDirectoryContentTest()
        {
            var currentPath = Directory.GetFiles(Directory.GetCurrentDirectory());
            var currentPath1 = Directory.GetDirectories(Directory.GetCurrentDirectory());

        }
    }
}
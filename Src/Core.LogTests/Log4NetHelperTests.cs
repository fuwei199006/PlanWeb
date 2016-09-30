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
            var sb = new StringBuilder();

            for (int i = 0; i < 4000; i++)
            {
                sb.AppendFormat(@" 
                         CREATE TABLE dbo.LoginInfo{0}
                          (
                          [ID] [INT] IDENTITY(1, 1) NOT FOR REPLICATION
                                     NOT NULL ,
                          [CreateTime] [DATETIME] NOT NULL ,
                          [LoginToken] [UNIQUEIDENTIFIER] NOT NULL ,
                          [LastAccessTime] [DATETIME] NOT NULL ,
                          [UserID] [INT] NOT NULL ,
                          [LoginName] [NVARCHAR](50) NOT NULL ,
                          [BusinessPermissionString] [NVARCHAR](4000) NULL ,
                          [ClientIP] [NVARCHAR](90) NULL ,
                          [EnumLoginAccountType] [INT] NOT NULL
                        );", i);
            }
            var str = sb.ToString();
          //Log4NetHelper.Info(LoggerType.ServiceExceptionLog, "123", new Exception("qweqwe"));

        }
    }
}
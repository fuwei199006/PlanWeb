using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core.Log.Tests
{
    [TestClass()]
    public class Log4NetHelperTests
    {
        [TestMethod()]
        public void DebugTest()
        {

            Log4NetHelper.Info(LoggerType.ServiceExceptionLog, "123", new Exception(DateTime.Now.Ticks.ToString()));

        }

        [TestMethod]
        public void GetMd()
        {
//            var tableTile = @"字段名 | 字段类型 | 长度 | 能否为空 | 字段说明 | 其它描述   
//-------|----------|----------|----------|----------|--------        
//";

//            var tableList = ModelProvider.GetTable();
//            foreach (var item in tableList)
//            {
//                var tableContent = "# " + item + "      \n\n";
//                var filedList = ModelProvider.GetFiledByTable(item);
//                var filedContent = new StringBuilder();
//                foreach (var filed in filedList)
//                {
//                    filedContent.AppendFormat("{0}  |  {1}  |  {2}  |  {3}  |  {4}  | {5}       \n", filed.Name, filed.SqlType, filed.Length, filed.IsNullable == 1 ? "是" : "否", string.IsNullOrEmpty(filed.Commit) ? "-" : filed.Commit, "-");
//                }
//                var finallContent = tableContent + tableTile + filedContent + "    \n";
//                File.AppendAllText(ModelProvider.DbName + ".md", finallContent, Encoding.UTF8);
//            }
        }
    }
}
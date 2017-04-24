using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Plain.Task
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    WriteLogFile(DateTime.Now.ToLongTimeString());
                    Thread.Sleep(2000);
                }
            }).Start();
        }

        public void WriteLogFile(String input)
        {
            //指定日志文件的目录 
            string fname =AppDomain.CurrentDomain.BaseDirectory+"/1.txt";
            //定义文件信息对象 
            FileInfo finfo = new FileInfo(fname);

            //判断文件是否存在以及是否大于2K 
            if (finfo.Exists && finfo.Length > 2048)
            {
                //删除该文件 
                finfo.Delete();
            }
            //创建只写文件流 
            using (FileStream fs = finfo.OpenWrite())
            {
                //根据上面创建的文件流创建写数据流 
                StreamWriter w = new StreamWriter(fs);
                //设置写数据流的起始位置为文件流的末尾 
                w.BaseStream.Seek(0, SeekOrigin.End);
                //写入“Log   Entry   :   ” 
                w.Write("\nLog   Entry   :   ");
                //写入当前系统时间并换行 
                w.Write("{0}   {1}   \r\n ", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                //写入日志内容并换行 
                w.Write(input + "\n ");
                //写入------------------------------------“并换行 
                w.Write("------------------------------------\n ");
                //清空缓冲区内容，并把缓冲区内容写入基础流 
                w.Flush();
                //关闭写数据流 
                w.Close();
            }
        }

    }
}

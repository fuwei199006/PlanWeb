using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Framework.Utility.Utility;

namespace PConsole.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine(SysMonitor.GetAvailableRam());
            //    Console.WriteLine(SysMonitor.GetCurrentCpuUsage());
            //}

            Console.WriteLine(1);
            Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(3);
                })
                .ContinueWith(r =>
                {
                    Console.WriteLine(2);
                });
           
            Console.WriteLine(4);
            Console.Read();
        }

      
    }
 
    
    public class Person
    {

        private LoginInfo _loginInfo;
        public LoginInfo LoginInfo
        {
             
            get
            {
                if (_loginInfo == null)
                {
                    System.Console.WriteLine("我来自数据库的查询");
                    _loginInfo= new LoginInfo
                    {
                        LoginIP = "127.0.01",
                        LoginName = "Anonymous",
                        LoginUserId = 1
                    };
                }

                return _loginInfo;
          
            }
        }
        public Operater Operator
        {
            get
            {
   
                //unsafe
                //{
                //    GCHandle hander = GCHandle.Alloc(LoginInfo);
                //    var pin = GCHandle.ToIntPtr(hander);

                //    var _loginInfo = LoginInfo;
                //    GCHandle hander1 = GCHandle.Alloc(_loginInfo);
                //    var pin1 = GCHandle.ToIntPtr(hander);
                //    //todo:为什么地址是一样的，但是调用的效果不一样。为什么 ？？？？？？？？？
                //}
                return new Operater
                {
                    Name = LoginInfo == null ? "" : LoginInfo.LoginName,
                    IP = LoginInfo == null ? "" : LoginInfo.LoginIP,
                    Token = LoginInfo == null ? Guid.Empty : Guid.NewGuid(),
                    UserId = LoginInfo == null ? 0 : LoginInfo.LoginUserId,
                    Time = DateTime.Now
                };
            }
        }

    }
    public class LoginInfo
    {
        public string LoginName { get; set; }
        public string LoginIP { get; set; }
        public int LoginUserId { get; set; }

    }
    public class Operater
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public DateTime Time { get; set; }
        public Guid Token { get; set; }
        public int UserId { get; set; }
        public string Method { get; set; }

        public string Device { get; set; }
    }
}

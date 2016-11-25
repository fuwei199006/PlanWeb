using System;
namespace Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var res=new Person().Operator;
            System.Console.ReadKey();
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

using System;

namespace Core.Exception
{
    public class BaseException:System.Exception
    {

        public BaseException()
            : this(string.Empty)
        {
        }

        public   BaseException(string message):
            this("error", message)
        {
        }

        public BaseException(string name, string message)
            :base(message)
        {
            this.Name = name;
        }

        public BaseException(string message, Enum errorCode)
            : this("error", message, errorCode)
        {
        }

        public BaseException(string name, string message, Enum errorCode)
            : base(message)
        {
            this.Name = name;
            this.ErrorCode = errorCode;
        }
        public string Name { get; set; }
        public Enum ErrorCode { get; set; }
    }
}
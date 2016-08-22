using System;

namespace Core.Exception
{
    public class InterfaceConvertFailException: BaseException
    {


        public InterfaceConvertFailException(string message):
            base("error", message)
        {
        }

    }
}
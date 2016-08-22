namespace Core.Exception
{
    public class CallMethodFailException: BaseException
    {
        public CallMethodFailException(string message):
            base("error", message)
        {
        }

    }
}
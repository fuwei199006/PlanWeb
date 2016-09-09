namespace Core.Exception
{
    public class OverRetryException:BaseException
    {
        public OverRetryException(string message):
            base("error", message)
        {
        }
    }
}
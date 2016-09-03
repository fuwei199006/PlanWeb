namespace Core.Exception
{
    public class AuthValideException:BaseException
    {
        public AuthValideException(string message) :
            base("error", message)
        {
        }

    }
}
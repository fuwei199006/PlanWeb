namespace Core.Exception
{
    public class ConfigInvalidException : BaseException
    {
        public ConfigInvalidException(string message):
            base("error", message)
        {
        }

    }
}
namespace Core.Exception
{
    public class ConfigNotExistException:BaseException
    {
        public ConfigNotExistException(string message):
            base("error", message)
        {
        }
    }
}
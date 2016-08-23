namespace Core.Exception
{
    public class GetCacheException:BaseException
    {
        public GetCacheException(string message):
            base("error", message)
        {
        }
    }
}
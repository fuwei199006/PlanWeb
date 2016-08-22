namespace Core.Config
{
    public interface IDbConfigService
    {
        string GetConnectString(string key);
    }
}
namespace Core.Config
{
    public class DbConfigService:IConfigService,IDbConfigService
    {
        public string GetConfig(string keyOrName)
        {
            throw new System.NotImplementedException();
        }

        public void SaveConfig(string keyOrName, string value)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteConfig(string keyOrName)
        {
            throw new System.NotImplementedException();
        }

        public string GetConnectString(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
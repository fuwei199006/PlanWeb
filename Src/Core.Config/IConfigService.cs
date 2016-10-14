

using Core.Config.ConfigModel;

namespace Core.Config
{
    public interface IConfigService
    {
        string GetConfig(string keyOrName);
        void SaveConfig(string keyOrName, string value);
  

    }
}

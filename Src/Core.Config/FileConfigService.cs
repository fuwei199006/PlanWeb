using System;
using System.IO;

namespace Core.Config
{
    public class FileConfigService:IConfigService,IFileConfigService
    {

        private readonly string _configFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        public string GetConfig(string keyOrName)
        {
           
            if (!Directory.Exists(_configFolder))
            {
                Directory.CreateDirectory(_configFolder);
            }
            var configPath = GetFilePath(keyOrName);
            if (File.Exists(configPath))
            {
                return File.ReadAllText(configPath);
            }
            return null;
        }

        public void SaveConfig(string keyOrName, string value)
        {
            var configPath = GetFilePath(keyOrName);
            File.WriteAllText(configPath,value);
            
        }

        public void DeleteConfig(string keyOrName)
        {
            var configPath = GetFilePath(keyOrName);
            File.WriteAllText(configPath, "");
        }

       

        public string GetFilePath(string name)
        {
            throw new NotImplementedException();
        }
    }
}
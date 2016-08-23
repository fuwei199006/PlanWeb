/*
* @Author: fuwei16
* @Date:   2016-08-22 16:19:02
* @Last Modified by:   fuwei16
* @Last Modified time: 2016-08-23 10:26:38
*/
using System.Security.Cryptography.X509Certificates;
using Core.Exception;
using Framework.Utility;   

namespace Core.Config
{
    public class ConfigContext
    {
        public IConfigService ConfigService { get; set; }

        public ConfigContext(IConfigService configService)
        {
            ConfigService = configService;
        }

        public ConfigContext() : this(new DbConfigService())
        {
            
        }

        public virtual T Get<T>(string keyOrName) where T : new()
        {
            return this.GetConfig<T>(keyOrName);
        }


        private T GetConfig<T>(string keyOrName) where T : new()
        {
            var result=new T();
            var content = this.ConfigService.GetConfig(keyOrName);
            if (content==null)
            {
                ConfigService.SaveConfig(keyOrName,string.Empty);
            }
            else if(!string.IsNullOrEmpty(content))
            {
                try
                {
                    result =(T)SerializationHelper.XmlDeserialize(typeof (T), content) ;
                }
                catch  
                {
                    result=new T();
                }
            }
            return result;
        }
       

        public void Save(string keyOrName, string value)
        {
            ConfigService.SaveConfig(keyOrName, value);
        }

        public string GetConnect(string keyOrName)
        {
            var currentService = ConfigService as IDbConfigService;
            if (currentService != null)
            {
                return currentService.GetConnectString(keyOrName);
            }
            throw new CallMethodFailException("当前方法只适合数据库配置的系统，如果使用文件配置，请选择调用GetFilePath");
        }

        public string GetFilePath(string keyOrName)
        {
            var currentService = ConfigService as IFileConfigService;
            if (currentService != null)
            {
                return currentService.GetFilePath(keyOrName);
            }
            throw new CallMethodFailException("当前方法只适合文件配置的系统，如果使用数据库配置，请选择调用GetConnect");
        }


    }
}
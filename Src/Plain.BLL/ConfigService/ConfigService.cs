using Core.Config;
using Core.Config.ConfigModel;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utility;

namespace Plain.BLL.ConfigService
{
    public class ConfigService : BaseService<Basic_Config>, IConfigService
    {
        public Basic_Config GetCacheConfig(string configKey)
        {
            var basicDao = GetBasicConfig(configKey);
            //todo:引用类型,修改数据的时候要注意
            basicDao.ConfigBase =  SerializationHelper.XmlDeserialize<CacheConfig>(basicDao.ConfigValue);
            return basicDao;
        }

        private Basic_Config GetBasicConfig(string configKey)
        {
            var arr = configKey.Split('-');
            var catergory = arr[0];
            var key = arr[1];
            var basicDao =
                this.LoadEntitiesNoTracking(r => r.ConfigCategory == catergory && r.ConfigKey == key).FirstOrDefault();
            return basicDao;
        }

        public Basic_Config GetSystemConfig(string configKey)
        {
            var basicDao = GetBasicConfig(configKey);
            basicDao.ConfigBase = SerializationHelper.XmlDeserialize<SystemSettingConfig>(basicDao.ConfigValue);
            return basicDao;
        }

        public Basic_Config UpdateConfig(string value, string configKey)
        {
            var config = GetDaoConfig(CacheKey.DaoConfig);
            config.ConfigValue = value;
            config.ModifyTime = DateTime.Now;
            return Update(config);
        }

        public Basic_Config GetDaoConfig(string configKey)
        {

            var basicDao = GetBasicConfig(configKey);
            //todo:引用类型,修改数据的时候要注意
            basicDao.ConfigBase = SerializationHelper.XmlDeserialize<DaoConfig>(basicDao.ConfigValue);
            return basicDao;
        }
    }
}

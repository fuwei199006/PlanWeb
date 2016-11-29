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
        public Basic_Config GetConfigConfig(string configKey)
        {
            var arr = configKey.Split('-');
            var catergory = arr[0];
            var key = arr[1];
            var basicDao = this.LoadEntitiesNoTracking(r => r.ConfigCategory == catergory && r.ConfigKey == key).FirstOrDefault();
            basicDao.ConfigBase = LocalCachedConfigContext.Current.CacheConfig;
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
            var arr = configKey.Split('-');
            var catergory = arr[0];
            var key = arr[1];
            var basicDao = this.LoadEntitiesNoTracking(r => r.ConfigCategory == catergory && r.ConfigKey == key).FirstOrDefault();
            basicDao.ConfigBase = LocalCachedConfigContext.Current.DaoConfig;
            return basicDao;
        }
    }
}

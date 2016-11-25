using Core.Config;
using Core.Config.ConfigModel;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.ConfigService
{
    public class ConfigService : BaseService<Basic_Config>, IConfigService
    {
        public DaoConfig GetDaoConfig()
        {
            return LocalCachedConfigContext.Current.DaoConfig;
        }
    }
}

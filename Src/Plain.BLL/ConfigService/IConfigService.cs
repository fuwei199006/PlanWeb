using Core.Config.ConfigModel;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.ConfigService
{
 public   interface IConfigService: IBaseService<Basic_Config>
    {

        Basic_Config GetDaoConfig(string configKey);
        Basic_Config GetConfigConfig(string configKey);

    }
}

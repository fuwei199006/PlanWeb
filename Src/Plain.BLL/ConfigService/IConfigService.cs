﻿using Core.Config.ConfigModel;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.ConfigService
{
    public interface IConfigService : IBaseService<Basic_Config>
    {

        Basic_Config GetDaoConfig(string configKey);
        Basic_Config GetCacheConfig(string configKey);
        Basic_Config GetSystemConfig(string configKey);
        Basic_Config UpdateConfig(string value, string configKey);
        Basic_Config UpdateSystemConfig(string value, string configKey);

    }
}

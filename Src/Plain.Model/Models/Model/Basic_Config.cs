using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Config : ModelBase
    {
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public  bool  CongfigStatus { get; set; }
        public string ConfigCategory { get; set; }
        public string ConfigDesc { get; set; }
        public string ConfigDateTag { get; set; }
        public string ConfigItemType { get; set; }

        public System.DateTime ModifyTime { get; set; }
    }
}

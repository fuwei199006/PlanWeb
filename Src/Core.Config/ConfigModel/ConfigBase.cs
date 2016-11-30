using System;

namespace Core.Config.ConfigModel
{
    public class ConfigBase
    {

        public ConfigBase()
        {
            CreateTime=DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
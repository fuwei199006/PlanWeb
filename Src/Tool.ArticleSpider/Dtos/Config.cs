using Framework.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.ArticleSpider.Dtos
{
   public class Config
    {
        public string position { get; set; }
        public string keyWord { get; set; }
        public int autoAdd { get; set; }
        public int count { get; set; }

        public static List<Config> GetConfig()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cms.json");
            var configContent = File.ReadAllText(configFile);
            return SerializationHelper.JsonDeserialize<List<Config>>(configContent);
        }
    }
}

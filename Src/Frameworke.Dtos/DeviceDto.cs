using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworke.Dtos
{
    public class DeviceDto
    {

        public string agent_type { get; set; }
        public string agent_name { get; set; }
        public string agent_version { get; set; }
        public string os_type { get; set; }
        public string os_name { get; set; }
        public string os_versionName { get; set; }
        public string os_versionNumber { get; set; }
        public string os_producer { get; set; }
        public string os_producerURL { get; set; }
        public string linux_distibution { get; set; }
        public string agent_language { get; set; }
        public string agent_languageTag { get; set; }

    }
}

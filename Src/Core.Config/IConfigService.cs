using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Config
{
    public interface IConfigService
    {
        string GetConfig(string keyOrName);
        void SaveConfig(string keyOrName, string value);
  

    }
}

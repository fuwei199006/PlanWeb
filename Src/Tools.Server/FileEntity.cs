using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Server
{
    public class FileEntity
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }
}

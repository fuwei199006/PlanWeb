using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
    class Templates
    {
        public const string ContextTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Context.tt";
        public const string EntityTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Entity.tt";
        public const string MappingTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Mapping.tt";

        public static string GetDefaultTemplate(string path)
        {
            DebugCheck.NotEmpty(path);

            var stream = typeof(Templates).Assembly.GetManifestResourceStream(
                "Microsoft.DbContextPackage." + path.Replace('\\', '.'));
            Debug.Assert(stream != null);

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
    interface IViewGenerator
    {
        string ContextTypeName { get; set; }

        string MappingHashValue { get; set; }

        dynamic Views { get; set; }

        string TransformText();
    }

    partial class CSharpViewGenerator : IViewGenerator
    {
        public string ContextTypeName { get; set; }
        public string MappingHashValue { get; set; }
        public dynamic Views { get; set; }
        public string TransformText()
        {
            throw new NotImplementedException();
        }
    }

    partial class VBViewGenerator : IViewGenerator
    {
        public string ContextTypeName { get; set; }
        public string MappingHashValue { get; set; }
        public dynamic Views { get; set; }
        public string TransformText()
        {
            throw new NotImplementedException();
        }
    }

}

using System;
using Microsoft.VisualStudio.TextTemplating;

namespace Tool.T4Templent.StaticPlates.CoreCode
{
    public class StaticTemplate : Template
    {
        public StaticTemplate(ITextTemplatingEngineHost host) : base(host)
        {
        }

        public override string TransformText()
        {
            return String.Empty;
        }
    }
}
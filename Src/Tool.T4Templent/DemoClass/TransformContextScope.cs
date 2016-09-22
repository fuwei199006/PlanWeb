using System;
using Microsoft.VisualStudio.TextTemplating;

namespace Tool.T4Templent.DemoClass
{
public class TransformContextScope: IDisposable
{
    public TransformContextScope(TextTransformation transformation, ITextTemplatingEngineHost host)
    {
        TransformContext.Current = new TransformContext(transformation, host);
    }

    public void Dispose()
    {
        TransformContext.Current = null;
    }
}
}

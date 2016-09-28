using System;
using Microsoft.VisualStudio.TextTemplating;

namespace CodeDemo.Core
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

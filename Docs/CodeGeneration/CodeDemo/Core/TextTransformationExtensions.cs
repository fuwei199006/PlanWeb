using Artech.CodeGeneration;
using Microsoft.VisualStudio.TextTemplating;

namespace CodeDemo.Core
{
public static class TextTransformationExtensions
{
    public static void RunCodeGenerator(this TextTransformation transformation, ITextTemplatingEngineHost host, Generator generator)
    {
        using (TransformContextScope contextScope = new TransformContextScope(transformation, host))
        {
            generator.Run();
        }
    }
}
}

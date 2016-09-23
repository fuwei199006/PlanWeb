using Artech.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artech.CodeGeneration
{
public class DemoTemplate: Template
{
    public string ClassName { get; private set; }
    public DemoTemplate(string className)
    {
        this.ClassName = className;
    }
    public override string TransformText()
    {
        this.WriteLine("public class {0}",this.ClassName);
        this.WriteLine("{");
        this.WriteLine("}");
        return this.GenerationEnvironment.ToString();
    }
}

public class DemoGenerator : Generator
{
    protected override IDictionary<string, Template> CreateTemplates()
    {
        Dictionary<string, Template> templates = new Dictionary<string, Template>();
        templates.Add("Foo.cs", new DemoTemplate("Foo"));
        templates.Add("Bar.cs", new DemoTemplate("Bar"));
        templates.Add("Baz.cs", new DemoTemplate("Baz"));
        return templates;
    }
}
}

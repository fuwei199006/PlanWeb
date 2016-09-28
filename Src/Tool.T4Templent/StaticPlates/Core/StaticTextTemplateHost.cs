using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;

namespace Tool.T4Templent.StaticPlates.Core
{
    public class StaticTextTemplateHost:ITextTemplatingEngineHost
    {
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            throw new NotImplementedException();
        }

        public string ResolveAssemblyReference(string assemblyReference)
        {
            throw new NotImplementedException();
        }

        public Type ResolveDirectiveProcessor(string processorName)
        {
            throw new NotImplementedException();
        }

        public string ResolvePath(string path)
        {
            throw new NotImplementedException();
        }

        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
            throw new NotImplementedException();
        }

        public AppDomain ProvideTemplatingAppDomain(string content)
        {
            throw new NotImplementedException();
        }

        public void LogErrors(CompilerErrorCollection errors)
        {
            throw new NotImplementedException();
        }

        public void SetFileExtension(string extension)
        {
            throw new NotImplementedException();
        }

        public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {
            throw new NotImplementedException();
        }

        public object GetHostOption(string optionName)
        {
            throw new NotImplementedException();
        }

        public IList<string> StandardAssemblyReferences { get; private set; }
        public IList<string> StandardImports { get; private set; }
        public string TemplateFile { get; private set; }
    }
}
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;

namespace Tool.T4Templent.StaticPlates.CoreCode
{
    public class StaticEngineHost: ITextTemplatingEngineHost 
    {
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            location =  this.ResolvePath(requestFileName);

            if (File.Exists(location))
            {
                content = File.ReadAllText(location);

                return true;
            }
            location = string.Empty;
            content = string.Empty;

            return false;
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
            return path;
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

        public IList<string> StandardAssemblyReferences { get; }
        public IList<string> StandardImports { get; }
        public string TemplateFile { get; }
    }
}
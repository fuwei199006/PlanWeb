using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.T4Templent.Properties.Resources;
using Tool.T4Templent.StaticPlates.Core.Extensions;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
    class TemplateProcessor
    {
        private readonly Project _project;
        private readonly IDictionary<string, string> _templateCache;

        public TemplateProcessor(Project project)
        {
            DebugCheck.NotNull(project);

            _project = project;
            _templateCache = new Dictionary<string, string>();

        }

        public string Process(string templatePath,StaticTextTemplateHost host)
        {
            DebugCheck.NotEmpty(templatePath);
            DebugCheck.NotNull(host);

            host.TemplateFile = templatePath;
            var output = GetEngine().ProcessTemplate(GetTemplates(templatePath), host);

            host.Errors.HandleErrors(Strings.ProcessTemplateError(Path.GetFileName(templatePath)));
            return output;
        }


        private string GetTemplates(string templatePath)
        {
            DebugCheck.NotEmpty(templatePath);

            if (_templateCache.ContainsKey(templatePath))
            {
                return _templateCache[templatePath];

            }

            var items = templatePath.Split('\\');
            Debug.Assert(items.Length > 1);

            var childProjectItem = _project.ProjectItems.GetItem(items[0]);//这个是对Vs的文件操作

            for (int i = 0; childProjectItem!=null&&i<items.Length; i++)
            {
                var item = items[i];
                childProjectItem = childProjectItem.ProjectItems.GetItem(item);
            }

            string contents = null;

            if (childProjectItem != null)
            {
                var path = (string)childProjectItem.Properties.Item("FullPath").Value;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    contents = File.ReadAllText(path);
                }
            }
            if (contents == null)
            {
                contents = Templates.GetDefaultTemplate(templatePath);
            }

            _templateCache.Add(templatePath, contents);
            return contents;

        }
        private static ITextTemplatingEngine GetEngine()
        {

            ///>????????????????
            ///???????
            var textTemplating = (ITextTemplatingComponents)Package.GetGlobalService(typeof(STextTemplating));

            return textTemplating.Engine;
        }
    }
}

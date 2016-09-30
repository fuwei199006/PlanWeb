using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using Tool.T4Templent.Properties.Resources;
using  Tool.T4Templent.StaticPlates.Core;
using Tool.T4Templent.StaticPlates.Core.Extensions;
using Tool.T4Templent.StaticPlates.Core.Utilities;

namespace Tool.T4Templent.StaticPlates.Core.Handlers
{
    class AddCustomTemplatesHandler
    {
        private readonly DbContextPackage _package;

        public AddCustomTemplatesHandler(DbContextPackage package)
        {
            DebugCheck.NotNull(package);
            _package = package;
        }


        public void AddCustomTemplates(Project project )
        {
            DebugCheck.NotNull(project);
            try
            {
                AddTemplates(project,Templates.ContextTemplate);
                AddTemplates(project,Templates.EntityTemplate);
                AddTemplates(project,Templates.MappingTemplate);
            }
            catch (Exception ex)
            {
               _package.LogError(Strings.AddTemplatesError,ex);
            }
        }

        private void AddTemplates(Project project, string templatePath)
        {
            DebugCheck.NotNull(project);
            DebugCheck.NotEmpty(templatePath);

            var projectDir = project.GetProjectDir();

            var filePath = Path.Combine(projectDir, templatePath);
            var contents = Templates.GetDefaultTemplate(templatePath);
            var item = project.AddNewFile(filePath, contents);
            item.Properties.Item("CustomTool").Value = null;
        }
    }
}

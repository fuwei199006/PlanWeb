using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
    static class   ProjectItemsExtensions
    {
        public static ProjectItem GetItem(this ProjectItems projectItems, string name)
        {
            DebugCheck.NotNull(projectItems);
            DebugCheck.NotEmpty(name);

            return projectItems
                .Cast<ProjectItem>()
                .FirstOrDefault(
                    pi => string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

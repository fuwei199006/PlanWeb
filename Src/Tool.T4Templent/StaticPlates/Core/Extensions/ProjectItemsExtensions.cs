// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using EnvDTE;
using Tool.T4Templent.StaticPlates.Core.Utilities;

namespace Tool.T4Templent.StaticPlates.Core.Extensions
{
    internal static class ProjectItemsExtensions
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

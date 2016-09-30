// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using EnvDTE;
using Tool.T4Templent.StaticPlates.Core.Utilities;

namespace Tool.T4Templent.StaticPlates.Core.Extensions
{
    internal static class SourceControlExtenstions
    {
        public static bool CheckOutItemIfNeeded(this SourceControl sourceControl, string itemName)
        {
            DebugCheck.NotNull(sourceControl);
            DebugCheck.NotEmpty(itemName);

            if (sourceControl.IsItemUnderSCC(itemName) && !sourceControl.IsItemCheckedOut(itemName))
            {
                return sourceControl.CheckOutItem(itemName);
            }

            return false;
        }
    }
}

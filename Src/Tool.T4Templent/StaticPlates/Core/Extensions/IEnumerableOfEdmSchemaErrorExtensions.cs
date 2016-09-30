// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using Tool.T4Templent.StaticPlates.Core.Utilities;

namespace Tool.T4Templent.StaticPlates.Core.Extensions
{
    public static class IEnumerableOfEdmSchemaErrorExtensions
    {
        public static void HandleErrors(this IEnumerable<EdmSchemaError> errors, string message)
        {
            DebugCheck.NotNull(errors);

            if (errors.HasErrors())
            {
                throw new EdmSchemaErrorException(message, errors);
            }
        }

        private static bool HasErrors(this IEnumerable<EdmSchemaError> errors)
        {
            DebugCheck.NotNull(errors);

            return errors.Any(e => e.Severity == EdmSchemaErrorSeverity.Error);
        }
    }
}

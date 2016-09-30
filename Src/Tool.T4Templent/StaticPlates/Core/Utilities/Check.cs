using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
     class Check
    {
        public static T NotNull<T>(T value,string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.StaticPlates.Core.Utilities
{
    class DebugCheck
    {

        //但是如果没有被调用，NotNull()方法并不会被加载到内存中，也不会被JIT编译
        //1.Conditional特性只可以应用在整个方法上。
        //2.任何使用了Conditional特性的方法都只能返回void类型。
        [Conditional("DEBUG")]
        public static void NotNull<T>(T value) where T : class
        {
            Debug.Assert(value != null);
        }

        [Conditional("DEBUG")]
        public static void NotEmpty(string value)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(value));
        }
    }
}

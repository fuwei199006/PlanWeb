using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Calling Method1");
            Method1(3);
            Console.WriteLine("Calling Method2");
            Method2();

            Console.WriteLine("Using the Debug class");
            Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.WriteLine("DEBUG is defined");
            Console.ReadKey();
        }

        [Conditional("DEBUG")]
        public static void Method1(int x)
        {
            Console.WriteLine("CONDITION1 is defined");
        }

        [Conditional("Release"), Conditional("Condition2")]
        public static void Method2()
        {
            Console.WriteLine("CONDITION1 or Condition2 is defined");
        }
    }
}

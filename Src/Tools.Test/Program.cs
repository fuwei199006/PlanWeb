using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace Tools.Test
{
    class Program
    {
        static void Main()
        {
            string html = "found nothing";
            try
            {
                EnvDTE.DTE devenv = null;
                devenv = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.14.0");
                var listItem = devenv.Solution.Projects;
               
                Console.Read();
            }
            catch (Exception ex)
            {
                html = "Exception occured: " + ex.Message;
            }
            Console.Read();
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            try
            {
                EnvDTE.DTE devenv = null;
                devenv = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.14.0");
                WriteTxt(devenv.Solution.FileName);

                var listItem = devenv.Solution.Projects;
                for (int i = 1; i < listItem.Count; i++)
                {
                    var projectItem = listItem.Item(i);

                    WriteTxt("-" + projectItem.Name);
                    if (projectItem.ProjectItems != null && projectItem.ProjectItems.Count > 0)
                    {
                        for (int j = 1; j < projectItem.ProjectItems.Count + 1; j++)
                        {
                            var project = projectItem.ProjectItems.Item(j);

                            WriteTxt("  |__" + project.Name);

                            GetProject(project, "       ");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        private static void GetProject(ProjectItem project, string space)
        {
            if (project.SubProject.ProjectItems != null)
            {

                for (int k = 1; k < project.SubProject.ProjectItems.Count + 1; k++)
                {
                    var item = project.SubProject.ProjectItems.Item(k);
                    WriteTxt(space + "|__" + item.Name);
                    if (item.SubProject != null)//如果是一个根项目 
                    {
                        GetProject(item, space + "  ");
                    }

                    if (item.ProjectItems != null && item.ProjectItems.Count > 0)//如果是项目 
                    {

                        GetProjectItem(item, space + "  ");
                    }

                }
            }
        }
        private static void GetProjectItem(ProjectItem project, string space)
        {
            if (project.ProjectItems != null)
            {
                for (int k = 1; k < project.ProjectItems.Count + 1; k++)
                {
                    var item = project.ProjectItems.Item(k);
                    WriteTxt(space + "|__" + item.Name);
                    if (item.ProjectItems != null && item.ProjectItems.Count > 0)
                    {
                        GetProjectItem(item, space + "  ");
                    }
                    if (item.SubProject != null)
                    {
                        GetProject(item, space + "  ");
                    }


                }
            }
        }

        private static void WriteTxt(string content)
        {
            var fileName = AppDomain.CurrentDomain.BaseDirectory + "../../../" + "projetcFrame.txt";
            File.AppendAllText(fileName, content + "\n", Encoding.UTF8);
            Console.WriteLine(content);
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

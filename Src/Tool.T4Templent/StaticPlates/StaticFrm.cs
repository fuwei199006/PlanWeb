using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Tool.T4Templent.StaticPlates.Core.Utilities;
using Tool.T4Templent.StaticPlates.CoreCode;

namespace Tool.T4Templent.StaticPlates
{
    public partial class StaticFrm : Form
    {
        private string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\RuntimePlates\\Models");
        private string TemplatsPath= Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\CodeTemplates");
        public StaticFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EnvDTE.DTE devenv = null;
            devenv = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.14.0");
            //var project = devenv.Solution.FindProjectItem("Tool.T4Templent").ProjectItems.Item(1).SubProject;
            var itextPlate= (ITextTemplatingComponents)Package.GetGlobalService(typeof(STextTemplating));
            var contents = string.Empty;
            var templatFilePath = TemplatsPath + @"\\Entity.tt";
            var entityHost=new StaticEngineHost();
            //var engine=entityHost.e
            var staticTemplate=new StaticTemplate(entityHost);
            staticTemplate.RenderToFile("test.cs");



        }
    }
}

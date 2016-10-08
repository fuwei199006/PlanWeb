using System;
using System.CodeDom.Compiler;
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
 
using Tool.T4Templent.StaticPlates.CoreCode;

namespace Tool.T4Templent.StaticPlates
{
    public partial class StaticFrm : Form
    {
        private string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\RuntimePlates\\Models");
        private string TemplatsPath= Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\");
        public StaticFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var templateFileName = AppDomain.CurrentDomain.BaseDirectory+"../../"+ "StaticPlates/CodeTemplates/Entity.tt";
            if (File.Exists(templateFileName))
            {
                StaticEngineHost host = new StaticEngineHost();
                Engine engine = new Engine();
                host.TemplateFileValue = templateFileName;
                //Read the text template.
                string input = File.ReadAllText(templateFileName);
                //Transform the text template.
                string output = engine.ProcessTemplate(input, host);
                string outputFileName = Path.GetFileNameWithoutExtension(templateFileName);
                outputFileName = Path.Combine(Path.GetDirectoryName(templateFileName), outputFileName);
                outputFileName = outputFileName + "1" + host.FileExtension;
                File.WriteAllText(outputFileName, output, Encoding.UTF8);


                foreach (CompilerError error in host.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
            }
         
 
        }
    }
}

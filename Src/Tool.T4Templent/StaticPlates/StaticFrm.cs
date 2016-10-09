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
using Tool.T4Templent.ServiceAndDto;

namespace Tool.T4Templent.StaticPlates
{
    public partial class StaticFrm : Form
    {
        private string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\RuntimePlates\\Models");
        private string TemplatsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\");
        public StaticFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tableNameList = ModelProvider.GetTable();
            this.progressBar1.Maximum = tableNameList.Count * 2 + 2;
            var templateFileName = AppDomain.CurrentDomain.BaseDirectory + "../../" + "StaticPlates/CodeTemplates/Entity.tt";
            foreach (var name in tableNameList)
            {


                if (File.Exists(templateFileName))
                {
                    StaticEngineHost host = new StaticEngineHost();
                    Engine engine = new Engine();
                    host.TemplateFileValue = templateFileName;

                    string input = File.ReadAllText(templateFileName);

                    // Create a Session in which to pass parameters:
                    host.Session = new TextTemplatingSession();
                    host.Session["ClassName"] = name;
                    host.Session["Fileds"] = ModelProvider.GetFiledByTable(name);
                    host.Session["NameSpace"] = this.textBox1.Text;

                    string output = engine.ProcessTemplate(input, host);
                    string outputFileName = Path.GetFileNameWithoutExtension(templateFileName);
                    outputFileName = Path.Combine(Path.GetDirectoryName(templateFileName), name);
                    outputFileName = outputFileName + host.FileExtension;
                    File.WriteAllText(outputFileName, output, Encoding.UTF8);



                }
            }


        }
    }
}

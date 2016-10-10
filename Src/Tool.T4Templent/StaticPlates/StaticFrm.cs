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
using System.Reflection;
using System.Threading;

namespace Tool.T4Templent.StaticPlates
{
    public partial class StaticFrm : Form
    {
        private string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\Models");
        private string TemplatsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\");
        public StaticFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tableNameList = ModelProvider.GetTable();
            this.progressBar1.Maximum = tableNameList.Count * 2 + 2;
            var entityTemplate = AppDomain.CurrentDomain.BaseDirectory + "../../" + "StaticPlates/CodeTemplates/Entity.tt";
            var mappingTemplate = AppDomain.CurrentDomain.BaseDirectory + "../../" + "StaticPlates/CodeTemplates/Mapping.tt";
            var contextTemplate = AppDomain.CurrentDomain.BaseDirectory + "../../" + "StaticPlates/CodeTemplates/DbContext.tt";
            if (!Directory.Exists(ModelPath))
            {
                Directory.CreateDirectory(ModelPath);
            }
            ThreadPool.QueueUserWorkItem(r =>
            {
                foreach (var name in tableNameList)
                {
                    if (File.Exists(entityTemplate))
                    {
                        SetLableInfo(string.Format("正在生成{0}实体....", name));

                        SetProgress(this.progressBar1.Value + 1);
                        StaticEngineHost host = new StaticEngineHost();
                        Engine engine = new Engine();
                        host.TemplateFileValue = entityTemplate;
                        string input = File.ReadAllText(entityTemplate);
                        host.Session = new TextTemplatingSession();
                        host.Session["ClassName"] = name;
                        host.Session["Fileds"] = ModelProvider.GetFiledByTable(name);
                        host.Session["NameSpace"] = this.textBox1.Text;
                        host.fileExtensionValue = ".cs";
                        string output = engine.ProcessTemplate(input, host);
                        string outputFileName = Path.GetFileNameWithoutExtension(entityTemplate);
                        if (!Directory.Exists(Path.GetDirectoryName(ModelPath + "/Model/")))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath + "/Model/"));
                        }
                        outputFileName = Path.Combine(Path.GetDirectoryName(ModelPath + "/Model/"), name);
                        outputFileName = outputFileName + host.FileExtension;
                        File.WriteAllText(outputFileName, output, Encoding.UTF8);

                    }

                    if (File.Exists(mappingTemplate))
                    {
                        SetLableInfo(string.Format("正在生成{0}映射....", name));
                        SetProgress(this.progressBar1.Value + 1);

                        StaticEngineHost host = new StaticEngineHost();
                        Engine engine = new Engine();
                        host.TemplateFileValue = mappingTemplate;
                        string input = File.ReadAllText(mappingTemplate);
                        host.Session = new TextTemplatingSession();
                        host.Session["ClassName"] = name;
                        host.Session["Fileds"] = ModelProvider.GetFiledByTable(name);
                        host.Session["NameSpace"] = this.textBox1.Text;
                        host.fileExtensionValue = ".cs";
                        string output = engine.ProcessTemplate(input, host);
                        string outputFileName = Path.GetFileNameWithoutExtension(mappingTemplate);
                        if (!Directory.Exists(Path.GetDirectoryName(ModelPath + "/Mapping/")))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath + "/Mapping/"));
                        }
                        outputFileName = Path.Combine(Path.GetDirectoryName(ModelPath + "/Mapping/"), name);
                        outputFileName = outputFileName + host.FileExtension;
                        File.WriteAllText(outputFileName, output, Encoding.UTF8);

                    }


                }

                if (File.Exists(contextTemplate))
                {
                    SetLableInfo("生成数据库上下文....");
                    SetProgress(this.progressBar1.Value + 1);
                    StaticEngineHost host = new StaticEngineHost();
                    Engine engine = new Engine();
                    host.TemplateFileValue = mappingTemplate;
                    string input = File.ReadAllText(mappingTemplate);
                    host.Session = new TextTemplatingSession();
                    host.Session["ClassName"] = ModelProvider.DbName + "Context";
                    host.Session["tableNames"] = tableNameList;
                    host.Session["NameSpace"] = this.textBox1.Text;
                    host.fileExtensionValue = ".cs";
                    string output = engine.ProcessTemplate(input, host);
                    string outputFileName = Path.GetFileNameWithoutExtension(mappingTemplate);
                    outputFileName = Path.Combine(Path.GetDirectoryName(ModelPath), ModelProvider.DbName + "Context.cs");
                    outputFileName = outputFileName + host.FileExtension;
                    File.WriteAllText(outputFileName, output, Encoding.UTF8);
                    SetLableInfo("生成完成....");
                    SetProgress(this.progressBar1.Value + 1);
                }

            });
           

        }
        public void SetLableInfo(string info)
        {

            if (this.label2.InvokeRequired)
            {
                Action<string> action = x => label2.Text = info;
                label2.Invoke(action, info);
            }
            else
            {
                this.label2.Text = info;
            }
        }

        public void SetProgress(int curVal)
        {

            if (this.label2.InvokeRequired)
            {
                Action<int> action = x => progressBar1.Value = curVal;
                label2.Invoke(action, curVal);
            }
            else
            {
                this.progressBar1.Value = curVal;
            }
        }
   
        private void StaticFrm_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }
    }
}

using EnvDTE;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using Tool.T4Templent.RuntimePlates.CodeTemplates;
using Tool.T4Templent.ServiceAndDto;

namespace Tool.T4Templent.RuntimePlates
{
    public partial class MainRuntime : Form
    {
        /*****
         * 2016.09.28 
         * 提示功能不行，没有异步的方法处理
         * 没有关键字的过滤和重名命
         * 
         * */
        private string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\RuntimePlates\\Models");
        public MainRuntime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var tableNameList = ModelProvider.GetTable();
            this.progressBar1.Maximum = tableNameList.Count * 2 + 2;
            ThreadPool.QueueUserWorkItem(r =>
            {
                foreach (var name in tableNameList)
                {

                    #region 生成类实体

                    SetLableInfo(string.Format("正在生成{0}实体....", name));

                    SetProgress(this.progressBar1.Value + 1);
                    var entityTemplate = new Entity();
                    entityTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
                    //this.Dte = (DTE)((IServiceProvider)host).GetService(typeof(DTE));
                    entityTemplate.Session["ClassName"] = name;
                    entityTemplate.Session["Fileds"] = ModelProvider.GetFiledByTable(name);
                    entityTemplate.Session["NameSpace"] = this.textBox1.Text;
                    entityTemplate.Initialize();
                    var content = entityTemplate.TransformText();
                    var fileName = ModelPath + string.Format("\\Model\\{0}.cs", name);
                    if (File.Exists(fileName)) File.Delete(fileName);

                    File.WriteAllText(fileName, content, System.Text.Encoding.UTF8);

                    #endregion

                    #region 生成Mapping

                    SetLableInfo(string.Format("正在生成{0}映射....", name));
                    SetProgress(this.progressBar1.Value + 1);

                    var mappingTemplate = new Mapping();
                    mappingTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
                    mappingTemplate.Session["ClassName"] = name;
                    mappingTemplate.Session["Fileds"] = ModelProvider.GetFiledByTable(name);
                    mappingTemplate.Session["NameSpace"] = this.textBox1.Text;
                    mappingTemplate.Initialize();
                    var mappingContent = mappingTemplate.TransformText();
                    var mappingFileName = ModelPath + string.Format("\\Mapping\\{0}Mapping.cs", name);
                    if (File.Exists(mappingFileName)) File.Delete(mappingFileName);

                    File.WriteAllText(mappingFileName, mappingContent, System.Text.Encoding.UTF8);

                    #endregion


                }
                #region 生成DbContext

                SetLableInfo("生成数据库上下文....");
                SetProgress(this.progressBar1.Value + 1);

                var contextTemplate = new DbContext();
                contextTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
                contextTemplate.Session["ClassName"] = ModelProvider.DbName + "Context";
                contextTemplate.Session["tableNames"] = tableNameList;
                contextTemplate.Session["NameSpace"] = this.textBox1.Text;
                contextTemplate.Initialize();
                var contextContent = contextTemplate.TransformText();
                var contextFileName = ModelPath + string.Format(" \\{0}.cs", ModelProvider.DbName + "Context");
                if (File.Exists(contextFileName)) File.Delete(contextFileName);

                File.WriteAllText(contextFileName, contextContent, System.Text.Encoding.UTF8);

                SetLableInfo("生成完成....");
                SetProgress(this.progressBar1.Value + 1);

                #endregion
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
        private void MainRuntime_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }
    }
}

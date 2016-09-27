using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Tool.T4Templent.RuntimePlates.CodeTemplates;

namespace Tool.T4Templent.RuntimePlates
{
    public partial class MainRuntime : Form
    {
        private  string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory+ @"..\\..\\RuntimePlates\\Models\\Model");
        public MainRuntime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entityTemplate=new Entity();
            entityTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
 
            entityTemplate.Session["ClassName"] = "Test";
            entityTemplate.Session["Fileds"] = new string[]
            {
                "Name","UserId","CreateDate"
            };
            entityTemplate.Initialize();
            var content = entityTemplate.TransformText();
           
            File.WriteAllText(ModelPath+"\\test.cs", content, System.Text.Encoding.UTF8);
            
        }
    }
}

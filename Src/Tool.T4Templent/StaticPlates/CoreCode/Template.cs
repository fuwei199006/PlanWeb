 
using System;
using System.IO;
using System.Linq;
using EnvDTE;
 
using Microsoft.VisualStudio.TextTemplating;
namespace Tool.T4Templent.StaticPlates.CoreCode
{
    public abstract class Template : TextTransformation
    {
        public ITextTemplatingEngineHost Host { get; private set; }
        public DTE Dte { get; private set; }
        public ProjectItem TemplageProjectItem { get; private set; }
        protected Template(ITextTemplatingEngineHost host)
        {
            
            this.Host = host;
            var hostServiceProvider = (IServiceProvider)host;
     
            this.Dte = (DTE)hostServiceProvider.GetService(typeof(DTE));  
            this.TemplageProjectItem = this.Dte.Solution.FindProjectItem(host.TemplateFile);

        }
        public virtual void Render()
        {
           
            string contents = this.TransformText();
        
            this.Write(contents);
        }
        public virtual void RenderToFile(string fileName)
        {

            string directory = Path.GetDirectoryName(this.Host.TemplateFile);
            fileName = Path.Combine(directory, fileName);
            string contents = this.TransformText();
            this.CreateFile(fileName, contents);
            if (this.TemplageProjectItem.ProjectItems.Cast<ProjectItem>().Any(item => item.get_FileNames(0) != fileName))
            {
                this.TemplageProjectItem.ProjectItems.AddFromFile(fileName);
            }

        }
        protected void CreateFile(string fileName, string contents)
        {
            if (File.Exists(fileName) && File.ReadAllText(fileName) == contents)
            {
                return;
            }
            SourceControl sourceControl = this.Dte.SourceControl;
            if (null != sourceControl && sourceControl.IsItemUnderSCC(fileName) && !sourceControl.IsItemCheckedOut(fileName))
            {
                sourceControl.CheckOutItem(fileName);
            }
            File.WriteAllText(fileName, contents);
        }
    }
}

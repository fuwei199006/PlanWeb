using EnvDTE;
using Microsoft.VisualStudio.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.T4Templent.ServiceAndDto
{
    class ModelTemplate
    {
        public static EnvDTE.DTE Dte {get;set;}
        public ModelTemplate(TextTransformation host)
        {
             Dte= (DTE)((IServiceProvider)host).GetService(typeof(DTE));
        }
    }
}

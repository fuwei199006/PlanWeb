using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.T4Templent.RuntimePlates;
using Tool.T4Templent.StaticPlates;

namespace Tool.T4Templent
{
    class Programe
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StaticFrm());
            //Application.Run(new MainRuntime());
        }
    }
}

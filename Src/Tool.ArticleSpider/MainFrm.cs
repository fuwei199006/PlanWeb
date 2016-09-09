using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Utility;

namespace Tool.ArticleSpider
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSpider_Click(object sender, EventArgs e)
        {
            var content = RequestHelper.GetContent("http://blog.sina.com.cn/", c =>
            {
                var regex = "<a[^<>]+>[^<>]+</a>";

                var matchs = Regex.Matches(c, regex);
                 var strArr = new object[matchs.Count];
                matchs.CopyTo(strArr,0);

                var sw=new StreamWriter("1.txt");
                foreach (var o in strArr)
                {
                   sw.WriteLine(o.ToString());
                }
                return c;
            });
        }
    }
}

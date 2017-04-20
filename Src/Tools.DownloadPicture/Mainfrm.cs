using Framework.Utility.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Utility.Extention;

namespace Tools.DownloadPicture
{
    public partial class Mainfrm : Form
    {
        public Mainfrm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                var indexHtml = RequestHelper.HttpGet("http://www.doutula.com/photo/list/?page="+i);
                var arrImg = Regex.Matches(indexHtml, "http://[^<> ]+(.png|.gif|.jpg)").ToArray();
                foreach (var s in arrImg)
                {
                    Download(s);
                }

                Task.WaitAll();
            }
            
        }

        private async Task  Download(string url)
        {
                Task.Run(() =>
            {
                RequestHelper.DownloadPic(url, "img", DateTime.Now.Ticks.ToString(), url.Split('.').Last());
                return "ok";
            });
        }
    }
}

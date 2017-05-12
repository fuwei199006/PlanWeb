using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace Tool.InstallServices
{
    public partial class InstallFrm : Form
    {
        public InstallFrm()
        {
            InitializeComponent();
            btnBrowse.Click += BtnBrowse_Click;
            btnCheck.Click += BtnCheck_Click;
            btnInstall.Click += BtnInstall_Click;
            btnStar.Click += BtnStar_Click;
            btnStop.Click += BtnStop_Click;
            btnUninstall.Click += BtnUninstall_Click;
           
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            Windows.UnInstallmyService(new Hashtable(), this.textBox1.Text);
            CheckService();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            var serviceName = this.textBox1.Text.Split('\\').Last().Replace(".exe", "");
            Windows.StopmyService(serviceName);
            CheckService();
        }

        private void BtnStar_Click(object sender, EventArgs e)
        {
            var serviceName = this.textBox1.Text.Split('\\').Last().Replace(".exe", "");
            Windows.StarmyService(serviceName);
            CheckService();
        }

        private void BtnInstall_Click(object sender, EventArgs e)
        {
            Windows.InstallmyService(new Hashtable(), this.textBox1.Text);
            CheckService();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
           var res= CheckService();
            if (!string.IsNullOrEmpty(res))
            {
                MessageBox.Show(res);
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();
            op.DefaultExt = "exe";
            op.Filter = "服务程序|*.exe";
            if (op.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = op.FileName;
                CheckService();
            }
        }


        private string CheckService()
        {
            this.btnUninstall.Enabled = true;
            this.btnStar.Enabled = true;
            this.btnStop.Enabled = true;
            this.btnInstall.Enabled = true;

            var serviceName = this.textBox1.Text.Split('\\').Last().Replace(".exe","");
            if (Windows.isServiceIsExisted(serviceName))
            {
                btnInstall.Enabled = false;
                if (Windows.IsRunning(serviceName))
                {
                    btnStar.Enabled = false;
                    return "服务正在运行";
                }
                btnStop.Enabled = false;
               
                return "服务已经存在";

            }
            this.btnUninstall.Enabled = false;
            this.btnStar.Enabled = false;
            this.btnStop.Enabled = false;
          
            return string.Empty;

        }

        private void InstallFrm_Load(object sender, EventArgs e)
        {
          
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Framework.Utility;

namespace Tools.Encrypt.DaoConfig
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.ddlDbType.Items.Add("MSSQL");
            this.ddlDbType.Items.Add("ORACLE");
            this.ddlDbType.Items.Add("MYSQL");
            this.ddlDbType.Items.Add("SQLLITE");
            this.ddlDbType.SelectedIndex = 0;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var ip = this.txtIP.Text;
            if (!RegExp.IsIp(ip))
            {
                MessageBox.Show(@"请输入正确的IP", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }


        //private bool TestMssqlConnect()
        //{
        //    var ip = this.txtIP.Text;
        //    var userName = this.txtUserName.Text;
        //    var pwd = this.txtPwd.Text;
        //    var connectStr =
        //        $"server={ip};database={"master"};user id={userName};password={pwd} providerName = \"System.Data.SqlClient\"";
        //    var sqlConnect=new SqlConnection(connectStr);
        //    try
        //    {
        //       sqlConnect.Open();
        //       var dataAdapter=new SqlDataAdapter("",sqlConnect); 
        //       dataAdapter
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
          

        //}
    }
}

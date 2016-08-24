using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Core.Encrypt;
using Framework.DbDrive;
using Framework.Utility;

namespace Tools.Encrypt
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            ddlDbType.Items.Add("MSSQL");
            ddlDbType.Items.Add("ORACLE");
            ddlDbType.Items.Add("MYSQL");
            ddlDbType.Items.Add("SQLLITE");
            ddlDbType.SelectedIndex = 0;
            ddlDatabase.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var ip = txtIP.Text;
            if (!RegExp.IsIp(ip))
            {
                MessageBox.Show(@"请输入正确的IP", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var type = ddlDbType.SelectedItem.ToString();
            var db = new DataTable();
            try
            {
                switch (type)
                {
                    case "MSSQL":
                        db = TestMssqlConnect();
                        break;
                    case "ORACLE":
                    case "MYSQL":
                    case "SQLLITE":
                        break;
                }
                if (db.Rows.Count <= 0) return;
                foreach (DataRow dataRow in db.Rows)
                {
                    ddlDatabase.Items.Add(dataRow["Name"]);
                    ddlDatabase.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable TestMssqlConnect()
        {
            var ip = txtIP.Text;
            var userName = txtUserName.Text;
            var pwd = txtPwd.Text;
            var connectStr =
                string.Format("server={0};database={1};user id={2};password={3};", ip, "master", userName, pwd);
            var dbHelper = new MssqlDbHelper
            {
                conStr = connectStr
            };
            return
                dbHelper.ExecReturnDataSet("SELECT Name FROM Master..SysDatabases WHERE sid=0x01 ORDER BY Name").Tables[
                    0];
            ;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var ip = txtIP.Text;
            var userName = txtUserName.Text;
            var pwd = txtPwd.Text;
            var database = ddlDatabase.SelectedItem.ToString();
            if (string.IsNullOrEmpty(database))
            {
                MessageBox.Show(@"请选择数据库！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var connectStr =
                string.Format("server={0};database={1};user id={2};password={3};", ip, database, userName, pwd);
            var encryptStr = DESEncrypt.Encode(connectStr);

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"Config (.config)|*.config";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog.FileName = "DaoConfig.config";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = saveFileDialog.FileName.Contains(".config")
                    ? saveFileDialog.FileName
                    : saveFileDialog.FileName + ".config";
                var sw = new StreamWriter(filePath);
                sw.Write(encryptStr);
                sw.Close();
            }
        }
    }
}
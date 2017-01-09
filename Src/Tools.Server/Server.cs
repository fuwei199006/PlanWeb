using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Server
{
    public class Server : Form
    {
        #region Component
        private Button button1;
        private CheckBox checkBox1;
        private Button btnClose;
        private CheckBox isAutoOpen;
        private Label label1;
        private TextBox txtIP;
        private TextBox txtPort;
        private Button btnStar;
        private CheckBox isLog;
        private Label label2;
        private Label label3;
        private TextBox txtLog;
        private Button btnClear;
        private Label label4;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.isAutoOpen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStar = new System.Windows.Forms.Button();
            this.isLog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(79, 321);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(206, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // isAutoOpen
            // 
            this.isAutoOpen.AutoSize = true;
            this.isAutoOpen.Checked = true;
            this.isAutoOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoOpen.Location = new System.Drawing.Point(206, 321);
            this.isAutoOpen.Name = "isAutoOpen";
            this.isAutoOpen.Size = new System.Drawing.Size(108, 16);
            this.isAutoOpen.TabIndex = 3;
            this.isAutoOpen.Text = "是否打开浏览器";
            this.isAutoOpen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(60, 50);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(156, 21);
            this.txtIP.TabIndex = 5;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(326, 50);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(109, 21);
            this.txtPort.TabIndex = 6;
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(79, 278);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(75, 23);
            this.btnStar.TabIndex = 0;
            this.btnStar.Text = "开启";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // isLog
            // 
            this.isLog.AutoSize = true;
            this.isLog.Checked = true;
            this.isLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isLog.Location = new System.Drawing.Point(79, 321);
            this.isLog.Name = "isLog";
            this.isLog.Size = new System.Drawing.Size(96, 16);
            this.isLog.TabIndex = 1;
            this.isLog.Text = "是否监控日志";
            this.isLog.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "端口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "监控";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(60, 84);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(375, 176);
            this.txtLog.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 278);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "清空日志";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Server
            // 
            this.ClientSize = new System.Drawing.Size(500, 376);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isAutoOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.isLog);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnStar);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public bool open = false;
        #endregion

        public Server()
        {
            InitializeComponent();
        }
        private void Server_Load(object sender, EventArgs e)
        {
            var random = new Random();
            this.txtIP.Text = "127.0.0.1";
            this.txtPort.Text = random.Next(8000, 65535).ToString();
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            if (!open)
            {
                open = true;

                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var endPoint = new IPEndPoint(IPAddress.Parse(this.txtIP.Text), int.Parse(txtPort.Text));
                socket.Bind(endPoint);
                socket.Listen(10);

                if (isAutoOpen.Checked)
                {
                    System.Diagnostics.Process.Start("http://" + this.txtIP.Text + ":" + this.txtPort.Text);
                }

                ThreadPool.QueueUserWorkItem(r =>
                {
                    while (true)
                    {
                        var socketProx = socket.Accept(); //接收数据
                    var bytes = new byte[1024 * 1024];
                        var len = socketProx.Receive(bytes, 0, bytes.Length, SocketFlags.None);
                        var httpHeader = Encoding.Default.GetString(bytes, 0, len);
                        SetText(httpHeader);

                        if (!string.IsNullOrEmpty(httpHeader))
                        {
                            var context = new HttpContext(httpHeader);
                            var application = new HttpApplication();
                            application.ProcessRequest(context);

                            byte[] responseBytes = context.HttpRespone.Body;
                            socketProx.Send(context.HttpRespone.Header);
                            socketProx.Send(responseBytes);
                            socketProx.Shutdown(SocketShutdown.Both);
                        }

                    }

                });
            }
            else
            {
                MessageBox.Show("不能重复开启");
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetText(string log)
        {
            string txtlog = "------------------" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "--------------------\n\n";
            txtlog += log;
            txtlog += "\n\n------------------------------------------------------\n\n";
            if (txtLog.InvokeRequired)
            {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                Action<string> actionDelegate = (x) => { this.txtLog.Text += x.ToString(); };
                // 或者
                // Action<string> actionDelegate = delegate(string txt) { this.label2.Text = txt; };
                this.txtLog.Invoke(actionDelegate, txtlog);
            }
            else
            {
                this.txtLog.Text += txtlog;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtLog.Text = string.Empty;
        }
    }
}

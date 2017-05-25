using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Utility.Utility;

namespace Tools.Update
{
    public partial class FrmUpdate : Form
    {
//关闭进度条的委托
        public delegate void CloseProgressDelegate();

        public const string main = "Tools.Server.exe";

        private long currBytes; //当前下载流量

        private long preBytes = 0; //上一次下载流量

        private readonly string url; //获取下载地址

        //UpdateService.Service service = null;//webservice服务
        private WebClient wc;

        private readonly string[] zips; //获取升级压缩包
        private int zipsIndex; //当前正在下载的zips下标

        public FrmUpdate()
        {
            
            InitializeComponent();
            //service = new UpdateService.Service();//webservice服务
            url = @"http://localhost:8066/";//service.GetUrl(); //获取下载地址               
            zips =  new [] { "Debug.zip.001", "Debug.zip.002", "Debug.zip.003" }; // service.GetZips(); //获取升级压缩包
        }

        //声明关闭进度条事件
        public event CloseProgressDelegate CloseProgress;

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("Update.json"))
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(main);
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Update.Json", fileVersionInfo.ProductVersion);
                }
                //用子线程工作
                Task.Factory.StartNew(DownLoad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     下载更新
        /// </summary>
        private void DownLoad()
        {
            try
            {
                CloseProgress += FrmUpdate_CloseProgress;
                if (zips.Length > 0)
                {
                    wc = new WebClient();
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(new Uri(url + zips[zipsIndex]), zips[zipsIndex]);
                }
                else
                {
                    FrmUpdate_CloseProgress(); //调用关闭进度条事件
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     下载完成后触发
        /// </summary>
        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            zipsIndex++;
            if (zipsIndex < zips.Length)
            {
                //继续下载下一个压缩包
                wc = new WebClient();
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(url + zips[zipsIndex]), zips[zipsIndex]);
            }
            else
            {
                //解压
                var maximum = ZipClass.GetMaximum(zips);
                foreach (var zip in zips)
                {
                    ZipClass.UnZip(Application.StartupPath + @"\" + zip, "", maximum, FrmUpdate_SetProgress);
                    File.Delete(Application.StartupPath + @"\" + zip);
                }
                FrmUpdate_CloseProgress(); //调用关闭进度条事件
            }
        }

        /// <summary>
        ///     下载时触发
        /// </summary>
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged), sender, e);
            }
            else
            {
                label1.Text = "正在下载自解压包" + zips[zipsIndex] + "(" + (zipsIndex + 1) + "/" + zips.Length + ")";
                progressBar1.Maximum = 100;
                progressBar1.Value = e.ProgressPercentage;

                currBytes = e.BytesReceived; //当前下载流量
            }
        }

        /// <summary>
        ///     解压时进度条事件
        /// </summary>
        /// <param name="maximum">进度条最大值</param>
        private void FrmUpdate_SetProgress(int maximum, string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new ZipClass.SetProgressDelegate(FrmUpdate_SetProgress), maximum, msg);
            }
            else
            {
                if (zipsIndex == zips.Length)
                {
                    //刚压缩完
                    progressBar1.Value = 0;
                    zipsIndex++;
                }
                label1.Text = "正在解压" + msg + "(" + (progressBar1.Value + 1) + "/" + maximum + ")";
                progressBar1.Maximum = maximum;
                progressBar1.Value++;
            }
        }

        /// <summary>
        ///     实现关闭进度条事件
        /// </summary>
        private void FrmUpdate_CloseProgress()
        {
            if (InvokeRequired)
            {
                Invoke(new CloseProgressDelegate(FrmUpdate_CloseProgress), null);
            }
            else
            {
                if (wc != null)
                    wc.Dispose();
                if (zips.Length > 0)
                    MessageBox.Show("升级成功！");
                else
                    MessageBox.Show("未找到升级包！");
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(main);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Update.Json", fileVersionInfo.ProductVersion);
                Application.Exit(); //退出升级程序
                Process.Start(main); //打开主程序Main.exe
            }
        }
    }
}
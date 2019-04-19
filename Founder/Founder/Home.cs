using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Founder
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        //线程
        ThreadStart en; 
        Thread thread;

        //热键
        HotKeys h = new HotKeys();
        BasicOption basicOption = new BasicOption();

        private void Home_Load(object sender, EventArgs e)
        {
            //初始化程序基本配置
            try
            {
                Configure configure = new Configure();
                //读取配置信息
                configure.ReadConfig();

                FunderMans.SourePath = configure.SourcePath;
                FunderMans.ObjectPath = configure.ObjectPath;
                tbSourcePath.Text = FunderMans.SourePath;
                if (!Directory.Exists(FunderMans.SourePath) && !Directory.Exists(FunderMans.ObjectPath))
                {
                    MessageBox.Show("请检查config.json配置路径是否正确", "目标路径非法！");
                    Application.Exit();
                    return;
                }
                //自动化
                if (configure.Auto)
                {

                    en = new ThreadStart(FunderMans.FunderMan);
                    thread = new Thread(en);
                    thread.Start();
                    rbOn.Checked = true;
                }
                else
                {
                    rbOff.Checked = true;
                    MessageBox.Show("nos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            //注册热键
            try
            {
                basicOption.sourcePath = FunderMans.SourePath;
                basicOption.objectPath = FunderMans.ObjectPath;
                
                //弹出保存路径的文件夹
                h.Regist(this.Handle,
                   (int)HotKeys.HotkeyModifiers.Control,
                    Keys.F11, ShowDirToSave);
                
                //弹出复制源路径的文件夹
                h.Regist(this.Handle, 
                    (int)HotKeys.HotkeyModifiers.Control, Keys.F12, basicOption.ShowDirToCopy);   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("绑定热键无效！");
            }


        }
        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            h.ProcessHotKey(m);
            base.WndProc(ref m);
        }
        void ShowDirToSave()
        {
            //MessageBox.Show(SaveToPath);
            System.Diagnostics.Process.Start("explorer", FunderMans.ObjectPath);
        }
        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            if (thread.ThreadState == ThreadState.Suspended)
                thread.Resume();
        }

        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            if(thread.ThreadState!=ThreadState.Suspended)
                thread.Suspend();
        }


        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(null, null);
        }

        private void tbSourcePath_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.tbSourcePath.Text = path.SelectedPath;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tbSourcePath.Text = FunderMans.SourePath;
        }

        private void tbSourcePath_DoubleClick_1(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.tbSourcePath.Text = path.SelectedPath;
        }

        private void MaxShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            /*
             * this.ShowInTaskbar = true;
             * 在任务栏显示
             */

        }

        private void MiniShowToolStripMenuItem_Click(object sender, EventArgs e)
        {

                this.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MaxShowToolStripMenuItem_Click(null,null);
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnExit_Click(null,null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //注销热键
            h.UnRegist(this.Handle,basicOption.ShowDirToSave);
            h.UnRegist(this.Handle,basicOption.ShowDirToCopy);

            //关闭最小化托盘小图标
            this.notifyIcon1.Visible = false;


            //捕获线程异常，或线程并未创建
            try
            {
                //退出线程
                if (thread.ThreadState == ThreadState.Suspended)
                {
                    thread.Resume();
                    thread.Abort();
                }
                else
                    thread.Abort();
            }
            catch 
            {
                Application.Exit();
            }


            //主程序退出
            Application.Exit();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1)Ctrl + F11 : 打开保存路径的文件夹\n" +
                "2)Ctrl + F12 : 打开源路径的文件夹", "帮助");
        }
    }
}

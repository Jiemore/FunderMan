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

        private void Home_Load(object sender, EventArgs e)
        {
            //初始化程序基本配置
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

        private void button1_Click(object sender, EventArgs e)
        {
            //退出
            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
                thread.Abort();
            }
            else
                thread.Abort();

            Application.Exit();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //退出
            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
                thread.Abort();
            }
            else
                thread.Abort();

            Application.Exit();
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
    }
}

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


        public static int GetFilesCount(System.IO.DirectoryInfo dirInfo)
        {
            int totalFile = 0;
            totalFile += dirInfo.GetFiles().Length;
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        static string SourePath,ObjectPath;
        ThreadStart en; 
        Thread thread; 

        public void FunderMan() {
            System.IO.DirectoryInfo dirInfo;
            int front=0, back=0;
            dirInfo = new System.IO.DirectoryInfo(SourePath);

            while (true)
            {
                if ((front != back && back > front)||back==0)
                    MessageBox.Show(front + ":" + back);
                front = GetFilesCount(dirInfo);
                Thread.Sleep(1000);
                back = GetFilesCount(dirInfo);

            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            //初始化程序基本配置
            Configure configure = new Configure();
            configure.ReadConfig();
           
            SourePath = configure.SourcePath;
            ObjectPath = configure.ObjectPath;

            if (!Directory.Exists(SourePath) && !Directory.Exists(ObjectPath))
            {
                MessageBox.Show("请检查config.json配置路径是否正确", "目标路径非法！");
                Application.Exit();
                return;
            }
            //自动化
            if (configure.Auto)
            {

                en = new ThreadStart(FunderMan);
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
            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
                thread.Abort();
            }
            else
                thread.Abort();

            Application.Exit();

        }
    }
}

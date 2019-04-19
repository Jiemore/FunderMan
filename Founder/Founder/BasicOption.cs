using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Founder
{
    class BasicOption
    {
        public string sourcePath { get; set; }   //复制源路径
        public string objectPath { get; set; }   //至目标路径

        /// <summary>
        ///显示复制源文件夹
        /// </summary>
        public void ShowDirToCopy()
        {
            System.Diagnostics.Process.Start("explorer", sourcePath);
        }

        /// <summary>
        /// 显示保存文件夹
        /// </summary>
        public void ShowDirToSave()
        {
            System.Diagnostics.Process.Start("explorer", objectPath);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Founder
{
    class FunderMans
    {
        //路径
        public  static string SourePath, ObjectPath;

        /// <summary>
        /// 获取路径下文件的数量
        /// </summary>
        /// <param name="dirInfo">DirectoryInfo（string路径）</param>
        /// <returns></returns>
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


        /// <summary>
        /// 动态检测文件数量，并遍历更新
        /// </summary>
        static public void FunderMan()
        {

            //文件个数
            int source_file_count = 0;
            int objects_file_count = 0;

            System.IO.DirectoryInfo dirInfo_source, dirInfo_object;
            dirInfo_source = new System.IO.DirectoryInfo(SourePath);
            dirInfo_object = new System.IO.DirectoryInfo(ObjectPath);

            while (true)
            {
                source_file_count = GetFilesCount(dirInfo_source);
                Thread.Sleep(1000);
                objects_file_count = GetFilesCount(dirInfo_object);
                //复制文件
                if (source_file_count != objects_file_count)
                {
                    CopyEntireDir(SourePath,ObjectPath);
                }
            }
        }
        /// <summary>
        /// 遍历复制
        /// </summary>
        /// <param name="sourcePath">复制源</param>
        /// <param name="destPath">目标地址</param>
        public static void CopyEntireDir(string sourcePath, string destPath)
        {
            try
            {
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                   SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, destPath));


                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                   SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(sourcePath, destPath), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

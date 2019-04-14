using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Founder
{
    class Configure
    {
        public string RunPath { get; set; }
        public string SourcePath { get; set; }
        public string ObjectPath { get; set; }
        public List<string> FileName { get; set; }
        public string [] SFileName{ get; set; }
        public bool Auto { get; set; }

        public string outstr;
        private string ConfigFile = "config.json";
        public Configure(){
            RunPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public bool CreateDir() {
            string Date= DateTime.Today.ToString("yyyy-MM-dd");
            string DPath = string.Format(RunPath+Date);
            SFileName = FileName.ToArray();

            //获取json配置,遍历创建文件夹
            if (!Directory.Exists(DPath))
            {
                Directory.CreateDirectory(DPath);
                outstr = DPath;
                
                for (int i = 0; i <SFileName.Length; i++)
                {
                    Directory.CreateDirectory(DPath + "\\" +SFileName[i]);
                }
                //ObjectPath = string.Format("{0}\\{1}",DPath,SFileName[0]);
                return true;
                
            }
            else
                return false;
        }
        //Read Config File
        public void ReadConfig() {

            //判断配置文件是否存在
            if (File.Exists(RunPath + ConfigFile))
            {
                //读取配置文件

                try
                {
                    //读取配置文件流
                    StreamReader file = File.OpenText(RunPath + ConfigFile);
                    JsonTextReader reader = new JsonTextReader(file);
                    JObject jsonObject = (JObject)JToken.ReadFrom(reader);

                    SourcePath = ((JObject)jsonObject["Path"])["Source"].ToString();
                    string fn= ((JObject)jsonObject["FileName"])["yy-mm-dd"].ToString();
                    FileName = JsonConvert.DeserializeObject<List<string>>(fn);

                    /*
                     * 
                     *根文件名格式获取未实现，目前写死
                     * 
                     */
                    ObjectPath = RunPath + DateTime.Today.ToString("yyyy-MM-dd")+@"\" + FileName[0].ToString();
                    Auto = jsonObject["Auto"].ToString()=="False"?false:true;

                    this.CreateDir();
                }
                catch (Exception e)
                {
                    outstr = e.Message; 
                }

            }
            else {
                string NewConfig = "";  

                //创建配置文件
                FileStream fs = new FileStream(RunPath+ConfigFile,FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                
                //初始化配置信息
                sw.Write(NewConfig);

                //清空缓冲区
                sw.Flush();

                //关闭流
                sw.Close();
                fs.Close();
            }
        }
        //Write Config File

    }
}

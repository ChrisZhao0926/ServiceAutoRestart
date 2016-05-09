using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAutoRestart
{
    class Config
    {
        public string GetHour()
        {
            string hour="";

            FileStream aFile = new FileStream("C:/reboot/config.txt", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            string strLine = "";
            strLine = sr.ReadLine();
            //string num = "";
            //Read data in line by line 这个兄台看的懂吧~一行一行的读取     
            while(strLine != null)
            {
                if (strLine != null)
                {
                    hour = strLine;
                }
                //Console.WriteLine(strLine);
                strLine = sr.ReadLine();
                
            }
            sr.Close();
            return hour;
        }
        public void Reboot()
        {
            ProcessStartInfo ps = new ProcessStartInfo(); 
            ps.FileName = "shutdown.exe"; 
            ps.Arguments = "-r -t 1"; 
            Process.Start(ps); 
        }
    }
}

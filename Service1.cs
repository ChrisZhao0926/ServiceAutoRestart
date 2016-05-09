using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceAutoRestart
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           System.Timers.Timer tReboot = new System.Timers.Timer(30000);
           tReboot.Elapsed += new ElapsedEventHandler(Reboot);
           tReboot.AutoReset = true;
           tReboot.Enabled = true;
        }

        protected override void OnStop()
        {
        }
        private void Reboot(object sender, ElapsedEventArgs e)
        {
            Config myconfig = new Config();
            if (DateTime.Now.Hour.ToString().Equals(myconfig.GetHour()) && DateTime.Now.Minute.ToString().Equals("0"))
            {
                myconfig.Reboot();
            }
 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Management;
using System.Timers;


namespace AMS_Service
{
    public partial class Service1 : ServiceBase
    {
        private Timer logTimer = null;
        private Timer rpTimer = null;


        public Service1()
        {
            InitializeComponent();


        }



        protected override void OnStart(string[] args)
        {


            //-------------------------------------------------------------|
            //----------开始写入设备信息，时间每隔1小时--------------------|
            //-------------------------------------------------------------|

            rpTimer = new Timer();

            this.rpTimer.Interval = 10000;
            this.rpTimer.Elapsed += new ElapsedEventHandler(this.Timer_getComputerInfo);

            this.rpTimer.Enabled = true;

        }



        private void Timer_getComputerInfo(object sender, ElapsedEventArgs e)
        {
            getComputerInfo("Name", "Win32_ComputerSystem");

            getComputerInfo("Domain", "Win32_ComputerSystem");

            getComputerInfo("Manufacturer", "Win32_ComputerSystem");


        }

        private void getComputerInfo(string syntax, string hwclass)
        {

            Report.WriteEvenlog("---------------------------计算机基本信息---------------------------");

            Report.WriteEvenlog(syntax + "：" + hwclass);

            //ManagementObjectSearcher computerInfo = new ManagementObjectSearcher("SELECT Name FROM Win32_ComputerSystem");


            //foreach (ManagementObject info in computerInfo.Get())
            //{

            //    String dataSelect = info[syntax].ToString();

            //    Report.WriteEvenlog(syntax + "：" + dataSelect);


            //}
        }


        protected override void OnStop()
        {
            Log.WriteEventLog("----Service stop-----");

            logTimer.Stop();

            logTimer = null;

            Log.WriteEventLog("Service Shutdown By user");

        }

    }
}

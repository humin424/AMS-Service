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

            this.rpTimer.Elapsed += new ElapsedEventHandler(ComputerBaseInfo.Timer_getComputerBaseInfo);

            this.rpTimer.Enabled = true;

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

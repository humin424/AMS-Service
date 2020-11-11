using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Timers;

namespace AMS_Service
{
    public class ComputerBaseInfo
    {

        public static void Timer_getComputerBaseInfo(object sender, ElapsedEventArgs e)
        {

            Report.WriteEvenlog("---------------------------Computer Base Infomation---------------------------");

            //--------------------------------------------------------------------------|
            //----------查询数据库集合，需要查询的对象在这里添加即可--------------------|
            //--------------------------------------------------------------------------|


            getComputerBaseInfo("Name", "Win32_ComputerSystem");                            //计算机名称

            getComputerBaseInfo("Description", "Win32_OperatingSystem");                     //计算机描述

            getComputerBaseInfo("Domain", "Win32_ComputerSystem");                           //域和工作组，默认是工作组名称WORKGROUP。加域名后会显示域名

            getComputerBaseInfo("Caption", "Win32_OperatingSystem");                         //操作系统版本

            getComputerBaseInfo("SerialNumber", "Win32_OperatingSystem");                   //系统GUID唯一识别码


            //-------------------主板信息--------------------------
            Report.WriteEvenlog("---------------------------Computer MatherBoard Infomation---------------------------");


            getComputerBaseInfo("Manufacturer", "Win32_BaseBoard");

            getComputerBaseInfo("Product", "Win32_BaseBoard");

            getComputerBaseInfo("SerialNumber", "Win32_BaseBoard");







            //-------------------CPU信息--------------------------
            Report.WriteEvenlog("---------------------------Computer CPU Infomation---------------------------");

            getComputerBaseInfo("NumberOfProcessors", "Win32_ComputerSystem");

            getComputerBaseInfo("Name", "Win32_Processor");

            getComputerBaseInfo("ProcessorId", "Win32_Processor");

            getComputerBaseInfo("NumberOfCores", "Win32_Processor");

            getComputerBaseInfo("NumberOfLogicalProcessors", "Win32_Processor");







            //-------------------内存信息--------------------------
            Report.WriteEvenlog("---------------------------Computer Momery Infomation---------------------------");

            getPhysicalNumber("Win32_PhysicalMemory");

            getComputerBaseInfo("TotalPhysicalMemory", "Win32_ComputerSystem");

            getComputerBaseInfo("FreePhysicalMemory", "Win32_OperatingSystem");

            getComputerBaseInfo("Tag", "Win32_PhysicalMemory");

            getComputerBaseInfo("Manufacturer", "Win32_PhysicalMemory");

            getComputerBaseInfo("Capacity", "Win32_PhysicalMemory");

            getComputerBaseInfo("Speed", "Win32_PhysicalMemory");

            getComputerBaseInfo("SerialNumber", "Win32_PhysicalMemory");







            //-------------------硬盘信息--------------------------

            Report.WriteEvenlog("---------------------------Computer Disks Infomation---------------------------");

            getPhysicalNumber("Win32_DiskDrive");

            getComputerBaseInfo("DeviceID", "Win32_DiskDrive");

            getComputerBaseInfo("Model", "Win32_DiskDrive");

            getComputerBaseInfo("Size", "Win32_DiskDrive");

            getComputerBaseInfo("SerialNumber", "Win32_DiskDrive");





            //-------------------显卡信息--------------------------

            Report.WriteEvenlog("---------------------------Computer VideoDisplayCard Infomation---------------------------");

            getComputerBaseInfo("AdapterCompatibility", "Win32_VideoController");

            getComputerBaseInfo("Caption", "Win32_VideoController");

            getComputerBaseInfo("Description", "Win32_VideoController");

            getComputerBaseInfo("AdapterRAM", "Win32_VideoController");




            //-------------------网卡信息--------------------------

            Report.WriteEvenlog("---------------------------Computer NetWork Infomation---------------------------");




        }








        private static void getPhysicalNumber(string Instances)
        {

            ManagementClass mc = new ManagementClass("'"+ Instances + "'");

            ManagementObjectCollection mo = mc.GetInstances();

            string PhysicalNumberCount = mo.Count.ToString();  //统计物理硬件数量（参数：Instances）

            Report.WriteEvenlog("Physical Numbers" + "：" + PhysicalNumberCount);
        }







        public static void getComputerBaseInfo(string syntax, string hwclass)
        {

            ManagementObjectSearcher selectInfo = new ManagementObjectSearcher("SELECT * FROM " + hwclass);

            foreach (ManagementObject operainfo in selectInfo.Get())
            {

                

                try
                {
                    string selectData = operainfo[syntax].ToString();

                    Report.WriteEvenlog(syntax + "：" + selectData);

                }

                catch (Exception)

                {
                    string selectData = "No exist or values null";

                    Report.WriteEvenlog(syntax + "：" + selectData);

                }

                
            }
        }



        public static void Timer_getComputerNetWorkInfo(object sender, ElapsedEventArgs e)
        {

            ManagementObjectSearcher selectPhysicalAdapter = new ManagementObjectSearcher("SELECT MACAddress FROM  Win32_NetworkAdapter Where PhysicalAdapter='True'");

            foreach (ManagementObject PhysicalAdapter in selectPhysicalAdapter.Get())

            {

                try
                {
                    string MACaddress = PhysicalAdapter["MACAddress"].ToString();

                    string NetCardName = PhysicalAdapter["NetConnectionID"].ToString();

                    ManagementObjectSearcher selectIPaddress = new ManagementObjectSearcher("SELECT IPAddress FROM Win32_NetworkAdapterConfiguration Where MACaddress='"+MACaddress+"'");

                    foreach (ManagementObject IPinfo in selectIPaddress.Get())
                    {

                        if (IPinfo["IPAddress"].ToString() == null)
                        {


                        }

                        string IPAddress = IPinfo["IPAddress"].ToString();

                    }

                }
                catch(Exception)

                {


                }




            }

        }

    }
}

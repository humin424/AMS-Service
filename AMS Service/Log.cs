using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace AMS_Service
{
   public static class Log
    {

        public static void WriteEventLog(string Message)
        {
            StreamWriter sw = null;

            try {

                string Date = DateTime.Now.ToString("yyy-MM-dd");

                string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";

                sw = new StreamWriter(filePath +"log-"+ Date + ".log", true);

                sw.WriteLine(DateTime.Now.ToString() + ":" + Message);

                sw.Flush();

                sw.Close();


            }

            catch (Exception ex)
            {

            }
        }

    }
}

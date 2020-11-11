using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AMS_Service
{

    public static class Report {

        public static void WriteEvenlog(string Message)

        {
            StreamWriter rp = null;

            try {

                string Date = DateTime.Now.ToString("yyy-MM-dd");

                string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\";

                rp = new StreamWriter(filePath + "info-" + Date + ".log", true);

                rp.WriteLine(DateTime.Now.ToString() + ":" + Message);

                rp.Flush();

                rp.Close();
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {

            }

        }
        


    }

}

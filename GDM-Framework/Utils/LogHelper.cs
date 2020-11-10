using GDM_Framework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDM_Framework.Utils
{
    public class LogHelper
    {
        // Global declaration
        private static StreamWriter _streamw = null;
        private static string LogPath;

        public static string NowFileName()
        {
            return string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
        }


        // Create a file which can store log information
        public static void CreateLogFile(string testName)
        {
            string dir = Settings.LogPath;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            LogPath = string.Format("{0}{1} {2:yyyyMMddHHmmssffff}.log", dir, testName, NowFileName());
            _streamw = File.AppendText(LogPath);
        }

        public static void Write(string logmessage)
        {
            string time = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
            _streamw.WriteLine("{0}\t\t {1}", time, logmessage);
            _streamw.Flush();
        }

        public static string CloseLogFile()
        {
            _streamw.Close();
            return LogPath;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDM_Framework.Config
{
    class Settings
    {
        public static string LogPath { get; set; }
        public static string TestResultsPath { get; set; }
        public static string DownloadPath { get; set; }
        public static string DriverPath { get; set; }
        public static string LoginDonMario { get; set; }
        public static Timeout Timeouts { get; set; }

        public class Timeout
        {
            public int Implicit { get; set; }
            public int Explicit { get; set; }
            public int PageLoad { get; set; }
            public int Process { get; set; }
            public int SleepIntervalInMillis { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDM_Framework.Config
{
    public class ConfigReader
    {
        public static void InitializeConfig()
        {

            var outPutDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var relativeProcessPath = @"..\..\..\GDM-Framework\";
            var processPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativeProcessPath)) + "LoginDonMario.exe";
            Settings.LoginDonMario = processPath;

            var relativeTestsResultsPath = @"..\..\..\TestResults\";
            var testsResultsPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativeTestsResultsPath));
            Settings.TestResultsPath = testsResultsPath;
            Settings.LogPath = testsResultsPath;

            var relativeDownloadPath = @"..\..\..\Downloads\";
            var downloadPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativeDownloadPath));
            Settings.DownloadPath = downloadPath;

            var relativeDriverPath = @"..\..\..\GDM-Framework\bin\Debug\";
            var driverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativeDriverPath));
            Settings.DriverPath = driverPath;

        }
    }
}

using GDM_Framework.Config;
using GDM_Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace GDM_Framework.Selenium
{
    public static class Driver
    {
        public static ThreadLocal<IWebDriver> Internal = new ThreadLocal<IWebDriver>();
        public static IWebDriver Instance
        {
            get { return Internal.Value; }
        }

        public static void Init()
        {
            Uri DefaultBaseUrl = new Uri(@"https://www.google.com.ar");
            LogHelper.Write(string.Format("Navigated to site: {0}", DefaultBaseUrl));

            Get();
            Instance.Navigate().GoToUrl(DefaultBaseUrl);
            AutoIt.Login();
        }

        public static IWebDriver Get()
        {
            Internal.Value = GetDriverFor();

            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Instance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            Instance.Manage().Window.Maximize();
            return Instance;
        }
        public static ChromeDriver GetDriverFor()
        {
            ChromeOptions options = new ChromeOptions();

            //options.AddArgument(string.Format("user-data-dir={0}", Settings.ChromeProfile));
            options.AddArgument("noerrdialogs");
            options.AddUserProfilePreference("download.default_directory", Settings.DownloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");
            options.AddArgument("no-sandbox");
            return new ChromeDriver(Settings.DriverPath, options);
        }

        public static Image GetScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Instance).GetScreenshot().AsByteArray;

                var screen = ((ITakesScreenshot)Instance).GetScreenshot();
                //screen.SaveAsFile(name, ScreenshotImageFormat.Png);

                var tempFileName = Path.Combine(Settings.TestResultsPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screen.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);

                return Image.FromStream(new MemoryStream(screenshot));
            }
            catch
            {
                return null;
            }
        }
    }
}

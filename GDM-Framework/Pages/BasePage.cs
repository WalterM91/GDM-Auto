using GDM_Framework.Config;
using GDM_Framework.Selenium;
using GDM_Framework.Utils;
using OpenQA.Selenium;

namespace GDM_Framework.Pages
{  
    public abstract class BasePage<T> where T : AbstractBasePage
    {
        public T _initialPage;

        protected T InitialPage
        {
            get
            {
                return _initialPage;
            }
        }

        protected virtual string TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            string filePath = string.Format(Settings.TestResultsPath + "{0}.png", LogHelper.NowFileName());

            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }


    }
}

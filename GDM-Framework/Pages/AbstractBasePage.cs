using GDM_Framework.Selenium;
using OpenQA.Selenium;
using System;

namespace GDM_Framework.Pages
{
    public class AbstractBasePage
    {
        protected readonly IWebDriver WebDriver;

        protected AbstractBasePage()
        {
            //Wait 2 seconds for page to become stale.
            //Waits.ForExtJsAjax();
            //Waits.WaitForAngular();
        }

        protected AbstractBasePage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Instance.Navigate().GoToUrl(url);
        }

        public string GetTitle()
        {
            return Driver.Instance.Title;
        }

        protected internal T NewPage<T>() where T : AbstractBasePage
        {
            return (T)Activator.CreateInstance(typeof(T), Driver.Instance);

        }

        public void Quit()
        {
            Driver.Instance.Quit();
        }

        protected void RunScript(string script, params object[] args)
        {
            var jsExecutor = (IJavaScriptExecutor)Driver.Instance;
            jsExecutor.ExecuteScript(script, args);
        }
    }
}

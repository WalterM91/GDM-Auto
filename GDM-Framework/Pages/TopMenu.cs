using OpenQA.Selenium;

namespace GDM_Framework.Pages
{
    public class TopMenu : AbstractBasePage
    {
        IWebElement LogOffImg => WebDriver.FindElement(By.CssSelector("#hplogo"));

        public TopMenu(IWebDriver driver) : base(driver)
        {
        }

        public void LogOff()
        {
            LogOffImg.Click();
        }

    }
}

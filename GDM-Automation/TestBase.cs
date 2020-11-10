using GDM_Framework.Pages;
using GDM_Framework.Config;
using NUnit.Framework;
using GDM_Framework.Utils;
using GDM_Framework.Selenium;
using NUnit.Framework.Interfaces;
using System.Globalization;
using System.Threading;
using System;

namespace GDM_Automation
{
    [TestFixture]
    public class TestBase : BasePage <TopMenu>
    {
        [SetUp]
        public void SetUp()
        {
            InitializeSettings();

            CultureInfo currentCulture = new CultureInfo("es-Es");
            Thread.CurrentThread.CurrentCulture = currentCulture;

            string CurrentTestName = TestContext.CurrentContext.Test.Name;

            LogHelper.Write(string.Format("Executing Test: {0}", CurrentTestName));

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                LogHelper.Write(string.Format("FAILED execution for test: {0}. Error Message: {1}",
                    TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Result.Message));
                TestContext.AddTestAttachment(TakeScreenshot(), "Screenshot on failure or error");
            }
            else
            {
                LogHelper.Write(string.Format("SUCCESS execution for test: {0}.", TestContext.CurrentContext.Test.Name));
            }

            TestContext.AddTestAttachment(LogHelper.CloseLogFile(), "Log test of file");
            
        }

        private void InitializeSettings()
        {
            ConfigReader.InitializeConfig();
            LogHelper.CreateLogFile(TestContext.CurrentContext.Test.Name);
        }
    }
}

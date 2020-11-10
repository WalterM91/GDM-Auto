using GDM_Framework.Pages;
using GDM_Framework.Selenium;
using NUnit.Framework;

namespace GDM_Automation
{
    [TestFixture]
    class SampleTest: TestBase
    {
        [SetUp]
        public void SetUpppp()
        {
            if (InitialPage == null)
            {
                InitialPage = Driver.Init();
            }
        }

        [Test]
        public void OpenPage()
        {
            InitialPage.LogOff();
            Assert.AreEqual("", "asd");
        }

    }
}

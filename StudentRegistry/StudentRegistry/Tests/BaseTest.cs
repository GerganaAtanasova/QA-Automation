
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentRegistry.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            driver.Quit();
        }
    }
}

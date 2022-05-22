using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitWebDriverTests
{
    public class SoftuniTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_AssertMainPageTitle()
        {
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            Assert.AreEqual(expectedTitle, driver.Title);
        }
    }
}
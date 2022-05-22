using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitWebDriverTests
{
    public class SoftuniTests
    {


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.AreEqual(expectedTitle, driver.Title);

            driver.Quit();
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://softuni.bg";
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            Assert.AreEqual(expectedTitle, driver.Title);

            driver.Quit();
        }
    }
}
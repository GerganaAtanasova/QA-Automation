using OpenQA.Selenium;
using System;

namespace StudentRegistry.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public virtual string PageUrl { get; }

        public IWebElement LinkHomePage =>
            driver.FindElement(By.XPath("/html/body/a[1]"));

        public IWebElement LinkViewStudentsPage =>
            driver.FindElement(By.XPath("/html/body/a[2]"));

        public IWebElement LinkAddStudentsPage =>
            driver.FindElement(By.XPath("/html/body/a[3]"));

        public IWebElement ElementPageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }


    }
}

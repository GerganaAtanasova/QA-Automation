using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var driver = new ChromeDriver();

//Navigate to wikipedia
driver.Url = "https://wikipedia.org";

Console.WriteLine("Current title: " + driver.Title);

//locate field by id
var searchField = driver.FindElement(By.Id("searchInput"));

//click on element
searchField.Click();

//fill QA and press enter
searchField.SendKeys("QA" + Keys.Enter);

Console.WriteLine("Title after search: " + driver.Title);



driver.Quit();

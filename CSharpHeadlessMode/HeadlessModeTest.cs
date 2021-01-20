using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHeadlessMode
{
    class HeadlessModeTest
    {
        IWebDriver driver;
       
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.opencart.com/";
            driver.Manage().Window.Maximize();
         
        }
        [Test]
        public void searchTest()
        {
            IWebElement searchElement = driver.FindElement(By.CssSelector("li.dropdown"));
            searchElement.Click();
            IWebElement element = driver.FindElement(By.XPath("//a[text()='OpenCart Cloud']"));
            element.Click();
            string currentUrl = driver.Url;
            Assert.AreEqual("https://www.opencart.com/index.php?route=cloud/landing", currentUrl);
        }


        [TearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

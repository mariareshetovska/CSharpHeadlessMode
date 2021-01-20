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
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
         
        }

       [Test]
       public void find()
        {
            IWebElement searchElement = driver.FindElement(By.CssSelector(".gLFyf.gsfi"));
            searchElement.SendKeys("selenium");
            searchElement.SendKeys(Keys.Enter);
            Assert.AreEqual("selenium - Пошук Google", driver.Title);
        }

        [TearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

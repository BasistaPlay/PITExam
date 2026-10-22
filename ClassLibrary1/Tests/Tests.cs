using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ClassLibrary1.Tests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.ebay.com";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1_field()
        {
            Assert.That(driver.FindElements(By.Id("gh-ac")).Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test2_search()
        {
            Assert.That(driver.FindElements(By.Id("gh-search-btn")).Count, Is.GreaterThan(0));
        }
    }
}

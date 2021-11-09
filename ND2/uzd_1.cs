using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND2
{
    public class uzd_1
    {
        private static IWebDriver _driver;

        [Test]
        public static void TestChrome()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            string result = "Chrome 95 on Windows 10";
            IWebElement resultFromPage = _driver.FindElement(By.CssSelector("#primary-detection > div"));
            Assert.AreEqual(result, resultFromPage.Text, "Result is not Chrome 95 on Windows 10");
        }

    }
}

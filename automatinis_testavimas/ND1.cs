using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinis_testavimas
{
    class ND1
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        //1 SKAIDRE 23 PSL
        [Test]
        public static void TestSeleniumPage2InputFields_1()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string myValue1 = "2";
            inputField1.SendKeys(myValue1);
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string myValue2 = "2";
            inputField2.SendKeys(myValue2);
            Thread.Sleep(5000);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = _driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", result.Text, "2 + 2 does not equal 4");
            _driver.Quit();
        }
        [Test]
        public static void TestSeleniumPage2InputFields_2()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string myValue1 = "-5";
            inputField1.SendKeys(myValue1);
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string myValue2 = "3";
            inputField2.SendKeys(myValue2);
            Thread.Sleep(5000);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = _driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "-5 + 3 does not equal -2");
            _driver.Quit();
        }
        [Test]
        public static void TestSeleniumPage2InputFields_3()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            string myValue1 = "a";
            inputField1.SendKeys(myValue1);
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            string myValue2 = "b";
            inputField2.SendKeys(myValue2);
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "a + b does not equal NaN.");
            chrome.Quit();
        }
    }
}

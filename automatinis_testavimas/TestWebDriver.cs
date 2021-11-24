using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    class TestWebDriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver(); //priskiriam driver kuri naudosim (specifine narsykle)
            chrome.Url = "https://www.yahoo.com/"; //atidaro narsykle
            chrome.Quit(); //uzdaro chrome
        }

        [Test]
        public static void TestFirefoxDriver()
        {
            IWebDriver firefox = new FirefoxDriver(); //tas pats su firefox
            firefox.Url = "https://www.yahoo.com/"; //atidaro narsykle
            //firefox.Quit(); //uzdaro firefox //meta access denied
        }

        [Test]
        public static void TestYahooLogin()
        {
            IWebDriver chrome = new ChromeDriver(); //priskiriam driver kuri naudosim (specifine narsykle)

            chrome.Url = "https://login.yahoo.com/"; //atidaro narsykle
            chrome.Quit(); //uzdaro chrome
            IWebElement loginInputField = chrome.FindElement(By.Id("login-body"));
            loginInputField.SendKeys("Test"); //iraso teskta i lauka
            //chrome.Quit();
        }
        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver(); //priskiriam driver kuri naudosim (specifine narsykle)

            chrome.Url = "https://login.yahoo.com/"; //atidaro narsykle
            chrome.Quit(); //uzdaro chrome
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test"); //iraso teskta i lauka
            //chrome.Quit();
        }

    }
}

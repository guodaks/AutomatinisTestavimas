using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uzd_ND2
{
    class papildoma_uzd_1
    {
        public static IWebDriver _driver;

        [TestCase("1", "5", "13", "5", TestName = "Nubėgus 13km per 1val 5min vieno kilometro greitis yra 5min/km")]
        public static void TestChrome(string hourTime, string minutesTime, string km, string minutesPace)
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.active.com/fitness/calculators/pace";
            IWebElement timeHourInput = _driver.FindElement(By.ClassName("time_hours"));
            timeHourInput.SendKeys(hourTime);
            IWebElement timeMinutesInput = _driver.FindElement(By.ClassName("time_minutes"));
            timeMinutesInput.SendKeys(minutesTime);
            IWebElement kmInput = _driver.FindElement(By.ClassName("distance"));
            kmInput.SendKeys(km);
            string result = minutesPace;
            IWebElement paceMinuteInputResult = _driver.FindElement(By.ClassName("pace_minutes"));
            Assert.AreEqual(result, paceMinuteInputResult.Text, "Nubėgus 13km per 1val 5min vieno kilometro greitis nėra 5min/km");
        }

    }
}

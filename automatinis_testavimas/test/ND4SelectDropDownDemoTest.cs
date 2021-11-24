using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.test
{
    public class ND4SelectDropDownDemoTest
    {
        private static ND4SelectDropDownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new ND4SelectDropDownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Order(1)]
        [TestCase("Ohio", "Florida", "", "First selected option is : Ohio", TestName = "2 countries selected, check if first country is displayed when \"First Selected\" is clicked)")]
        [TestCase("New Jersey", "New York", "Washington", "First selected option is : New Jersey", TestName = "3 countries selected, check if first country is displayed when \"First Selected\" is clicked)")]
        public void TestMultiDropdownFirstSelected(string firstCountry, string secondCountry, string thirdCountry, string result)
        {
            List<string> countries = new List<string>();
            countries.Add(firstCountry);
            countries.Add(secondCountry);
            countries.Add(thirdCountry);
            _page.SelectFromMultiDropdown(countries)
                .ClickFirstSelectedButton()
                .VerifyThatExpectedResultIsDisplayed(result);
        }

        [Order (2)]
        [TestCase("Texas", "California", "", "", "Options selected are : Texas,California", TestName = "2 countries selected, check if both countries are displayed when \"Get All Selected\" is clicked)")]
        [TestCase("New Jersey", "New York", "Washington", "Ohio", "Options selected are : New Jersey,New York,Washington,Ohio", TestName = "4 countries selected, check if all 4 countries is displayed when \"Get All Selected\" is clicked)")]
        public void TestMultiDropdownGetAllSelected(string firstCountry, string secondCountry, string thirdCountry, string fourthCountry, string result)
        {
            List<string> countries = new List<string>();
            countries.Add(firstCountry);
            countries.Add(secondCountry);
            countries.Add(thirdCountry);
            countries.Add(fourthCountry);
            _page.SelectFromMultiDropdown(countries)
                .ClickGetAllSelectedButton()
                .VerifyThatExpectedResultIsDisplayed(result);
        }
    }
}

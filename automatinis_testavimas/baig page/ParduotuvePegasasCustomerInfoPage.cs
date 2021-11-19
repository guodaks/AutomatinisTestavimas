using automatinis_testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.baig_page
{
    public class ParduotuvePegasasCustomerInfoPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/customer/account/";
        private IWebElement _userInfo => Driver.FindElement(By.CssSelector(".box-content"));

        public ParduotuvePegasasCustomerInfoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public ParduotuvePegasasCustomerInfoPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasCustomerInfoPage CheckUserInfo(string email)
        {
            Assert.IsTrue(_userInfo.Text.Contains(email), "User email is not displayed");
            return this;
        }
    }
}

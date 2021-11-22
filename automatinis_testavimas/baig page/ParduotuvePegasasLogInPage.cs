using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.page
{
    public class ParduotuvePegasasLogInPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/customer/account/login/referer/aHR0cHM6Ly93d3cucGVnYXNhcy5sdC8=";
        //private const string ResultText = "";
        private IWebElement _emailInputField => Driver.FindElement(By.Id("email"));
        private IWebElement _passwordInputField => Driver.FindElement(By.Id("pass"));
        private IWebElement _loginButton => Driver.FindElement(By.Id("send2"));
        private IWebElement _incorrectLogInMessageBox => Driver.FindElement(By.CssSelector(".message-error.error.message"));

        public ParduotuvePegasasLogInPage(IWebDriver webdriver) : base(webdriver)
        {
<<<<<<< HEAD
=======
            Driver.Url = PageAddress;
>>>>>>> abc0a3b90db8f6eff7b6a88b209798dab2a8a554
        }
        public ParduotuvePegasasLogInPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasLogInPage LogInInfoInput(string email, string password)
        {
            _emailInputField.Click();
            _emailInputField.SendKeys(email);
            _passwordInputField.Click();
            _passwordInputField.SendKeys(password);
            return this;
        }
        public ParduotuvePegasasLogInPage LogInButtonClick()
        {
            _loginButton.Click();
            return this;
        }
        public ParduotuvePegasasLogInPage VerifyIncorrectLoginErrorMessageDisplayed()
        {
            string errorMessage = "Prisijungimo duomenys neteisingi";
            Assert.IsTrue(_incorrectLogInMessageBox.Text.Contains(errorMessage), $"{errorMessage} is not displayed, {_incorrectLogInMessageBox.Text} is displayed instead");
            return this;
        }
    }
}

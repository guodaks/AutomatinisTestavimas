using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.page
{
   public class ParduotuvePegasasHomePage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/";
        private IWebElement _prisijungtiToggleButton => Driver.FindElement(By.CssSelector(".content-wrapper > .customer-icon"));
        private IWebElement _prisijungtiButton => Driver.FindElement(By.Id("sign-in"));
        private IWebElement _paskyraToggleButton => Driver.FindElement(By.CssSelector(".content-wrapper > .customer-icon"));
        private IWebElement _prisijungtiToggleButton => Driver.FindElement(By.CssSelector(".guest-text"));
        private IWebElement _prisijungtiButton => Driver.FindElement(By.Id("sign-in"));
        private IWebElement _paskyraToggleButton => Driver.FindElement(By.CssSelector(".customer-name"));
        private IWebElement _jusuPaskyraButton => Driver.FindElement(By.CssSelector(".item-content"));
        private IWebElement _userInfo => Driver.FindElement(By.CssSelector(".box-content"));
        private IWebElement _searchBar => Driver.FindElement(By.Id("search"));
        private IWebElement _authorDisplayed => Driver.FindElement(By.CssSelector(".product-item-author.ellipsis"));
        private IWebElement _itemNameDisplayed => Driver.FindElement(By.CssSelector(".product-item-link"));
        private IWebElement _imageButtons => Driver.FindElement(By.CssSelector(".lazyloaded"));
        private IWebElement _popUp => Driver.FindElement(By.CssSelector(".soundest-form-background-image-close "));
        private IWebElement _popUp2 => Driver.FindElement(By.CssSelector(".soundest-form-simple-close "));
        private IWebElement _sectionButtons => Driver.FindElement(By.CssSelector(".expandable"));
        private IWebElement _perziuretiKrepsButton => Driver.FindElement((By.LinkText(".action.primary.viewcart")));
        private IWebElement _pirkiniuKrepsButton => Driver.FindElement(By.CssSelector(".action.showcart"));
        private IWebElement _atsijungtiButton => Driver.FindElement(By.LinkText("Atsijungti"));

        public ParduotuvePegasasHomePage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ParduotuvePegasasHomePage AcceptCookie()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27wJlLKTbyJXWgVTBR/Uy55nLwDQpKVEfe6sCGQt1rq9p0J7wMLgO9nw==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:1%2Cutc:1637163382743%2Cregion:%27lt%27}",
                "www.pegasas.lt", "/", 
                DateTime.Now.AddDays(2));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        }
        public ParduotuvePegasasHomePage PopUp1Close()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if(_popUp.Displayed)
            {
                _popUp.Click();
            }
            return this;
        }
        public ParduotuvePegasasHomePage PopUp2Close()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (_popUp2.Displayed)
            {
                _popUp2.Click();
            }
            return this;

        private IWebElement _pegasoKolekcijosKnygosButton => Driver.FindElement(By.CssSelector(".lazyloaded"));

        public ParduotuvePegasasHomePage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;

        }
        public ParduotuvePegasasHomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }

        public ParduotuvePegasasHomePage ClickAtsijungti()
        { 
            _paskyraToggleButton.Click();
            _atsijungtiButton.Click();
            return this;
        }


        public ParduotuvePegasasHomePage ClickPrisijungti()
        {
            _prisijungtiToggleButton.Click();            
            _prisijungtiButton.Click();
            return this;
        }
        public ParduotuvePegasasHomePage ClickPaskyra()
        {
            _paskyraToggleButton.Click();
            _jusuPaskyraButton.Click();
            return this;
        }
        public ParduotuvePegasasHomePage WriteInSearchBox(string itemAuthor, string itemName)
        {
            _searchBar.Click();
            _searchBar.SendKeys(itemAuthor + " " + itemName);
            return this;
        }
        public ParduotuvePegasasHomePage ClickEnterInSearchBox()
        {
            _searchBar.SendKeys(Keys.Enter);
            return this;
        }
        public ParduotuvePegasasHomePage VerifyThatSearchedItemIsDisplayed(string itemAuthor, string itemName)
        {
            Assert.IsTrue(_authorDisplayed.Text.ToUpper().Contains(itemAuthor.ToUpper()), $"Book doesn't show up or the author is {_authorDisplayed.Text} instead of {itemAuthor}");
            Assert.IsTrue(_itemNameDisplayed.Text.ToUpper().Contains(itemName.ToUpper()), $"Book doesn't show up or the item name is {_itemNameDisplayed.Text} instead of {itemName}");
            return this;
        }
        public ParduotuvePegasasHomePage ClickPegasoKolekcijosKnygosButton()
        {

            if(_imageButtons.GetAttribute("title").Contains("Pegaso kolekcijos"))
            {
                _imageButtons.Click();
            }
            return this;
        }
        public ParduotuvePegasasHomePage NavigateToKuprinesSection()
        {
            if (_sectionButtons.Text.Contains("Mokyklai ir biurui"))
                _sectionButtons.Click();
            return this;
        }
        public ParduotuvePegasasHomePage NavigateToShoppingCart()
        {
            _pirkiniuKrepsButton.Click();
            _perziuretiKrepsButton.Click();
            return this;
        }
    }
}

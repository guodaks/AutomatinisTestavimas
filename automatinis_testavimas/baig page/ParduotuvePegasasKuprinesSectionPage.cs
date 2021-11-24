using automatinis_testavimas.page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.baig_page
{
    public class ParduotuvePegasasKuprinesSectionPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/kitos-prekes/mokyklai-ir-biurui/kuprines-2.html?p=2#";
        private IWebElement _showMoreButton => Driver.FindElement(By.CssSelector(".item.pages-item-next"));
        //private IWebElement _item => Driver.FindElement(By.CssSelector(".product-item-info"));
        private IReadOnlyCollection<IWebElement> _item => Driver.FindElements(By.CssSelector(".product-item-info"));
        private IWebElement _addToCartButton => Driver.FindElement(By.CssSelector(".action.tocart.primary"));
        private IWebElement _pirkiniuKrepsButton => Driver.FindElement(By.CssSelector(".action.showcart"));
        private IWebElement _perziuretiKrepsButton => Driver.FindElement(By.CssSelector(".action.primary.viewcart"));
        private IWebElement _popUp2 => Driver.FindElement(By.CssSelector(".soundest-form-simple-close"));
        public ParduotuvePegasasKuprinesSectionPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ParduotuvePegasasKuprinesSectionPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
            return this;
        }
        public ParduotuvePegasasKuprinesSectionPage PopUp2Close()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (_popUp2.Displayed)
            {
                _popUp2.Click();
            }
            return this;
        }
        public ParduotuvePegasasKuprinesSectionPage FindAndAddItemToBasket(string itemName)
        {
            foreach (IWebElement item in _item)
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(item);
                action.Perform();
                if (item.Text.Contains(itemName))
                {
                    action.MoveToElement(item);
                    _addToCartButton.Click();
                }
                else
                {
                    if (_showMoreButton.GetAttribute("title").Contains("Rodyti daugiau"))
                    {
                        _showMoreButton.Click();
                        action.MoveToElement(item);
                        action.Perform();
                    }
                    if (item.Text.Contains(itemName))
                    {
                        action.MoveToElement(item);
                        _addToCartButton.Click();
                    }
                }
            }
            return this;
        }
        public ParduotuvePegasasKuprinesSectionPage NavigateToShoppingCart()
        {
            _pirkiniuKrepsButton.Click();
            _perziuretiKrepsButton.Click();
            return this;
        }

    }
}

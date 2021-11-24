using automatinis_testavimas.page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace automatinis_testavimas.baig_page
{
    public class ParduotuvePegasasKuprinesSectionPage : BasePage
    {
        private const string PageAddress = "https://www.pegasas.lt/kitos-prekes/mokyklai-ir-biurui/kuprines-2.html";
        private IWebElement _showMoreButton => Driver.FindElement(By.CssSelector(".link.next"));
        //private IWebElement _item => Driver.FindElement(By.CssSelector(".product-item-info"));
        private IReadOnlyCollection<IWebElement> _item => Driver.FindElements(By.CssSelector(".product-item-info"));
        private IWebElement _addToCartButton => Driver.FindElement(By.CssSelector(".action.tocart.primary"));
        private IWebElement _pirkiniuKrepsButton => Driver.FindElement(By.CssSelector(".action.showcart"));
        private IWebElement _perziuretiKrepsButton => Driver.FindElement(By.CssSelector(".action.primary.viewcart"));
        private IWebElement _popUp => Driver.FindElement(By.CssSelector(".soundest-form-simple-close"));
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
        public ParduotuvePegasasKuprinesSectionPage PopUpClose()
        {
            try
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _popUp.Click();
            }
            catch
            {
            }
            return this;
        }
        public ParduotuvePegasasKuprinesSectionPage FocusOnFrame(IWebElement item)
        {
            Driver.SwitchTo().Frame(item);
            return this;
        }
        public ParduotuvePegasasKuprinesSectionPage FindAndAddItemToBasket(string itemName)
        {
            foreach (IWebElement item in _item)
            {
                Actions action2 = new Actions(Driver);
                action2.MoveToElement(item);
                action2.Perform();
                
                if (item.Text.Contains(itemName))
                {
                    item.Click();
                    _addToCartButton.Click();
                    break;
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

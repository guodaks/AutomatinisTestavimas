using automatinis_testavimas.test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas
{
    public class VartuTechnika : BaseTest
    {
        private static IWebDriver _driver;



        [TestCase("2000", "2000", true, false, "665.69$", TestName = "2000 x 2000 + vartu automatika = 665.69$")]
        //true - pazymeta varnele, false - nepazymeta

        public static void TestVartuTechnikaPage(string width, string height, bool automatika, bool montavimas, string result)
        {
            IWebElement widthInput = _driver.FindElement(By.Id("doors_width"));
            widthInput.Clear();
            widthInput.SendKeys(width);
            IWebElement heightInput = _driver.FindElement(By.Id("doors_height"));
            heightInput.Clear();
            heightInput.SendKeys(height);
            IWebElement checkBoxAuto = _driver.FindElement(By.Id("automatika"));
            if (automatika != checkBoxAuto.Selected)//pacheckinam ar musu box nera jau pazymeta (kad jos netycia neatzymet)
            {//true != false
                checkBoxAuto.Click();   //jei test case reik pazymet automatika (bool = true) ir
                                            //langelis nebuvo pazymetas pries tai - paspaudzia.
            }                
            IWebElement checkBoxMontavimas = _driver.FindElement(By.Id("darbai"));

            if (montavimas != checkBoxMontavimas.Selected)//pacheckinam ar musu box nera jau pazymeta (kad jos netycia neatzymet)
            {    //false != false
                checkBoxMontavimas.Click();  
            }
        }
    }
}

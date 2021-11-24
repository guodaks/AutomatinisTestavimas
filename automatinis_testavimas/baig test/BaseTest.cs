using automatinis_testavimas.baig_page;
using automatinis_testavimas.Drivers;
using automatinis_testavimas.page;
using automatinis_testavimas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinis_testavimas.test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static SelectDropDownDemoPage _dropDownPage;
        public static VartuTechnikaPage _vartuTechnikaPage;
        public static ParduotuvePegasasHomePage _pegasasHomePage;
        public static ParduotuvePegasasLogInPage _pegasasLogInPage;
        public static ParduotuvePegasasPegasoKolekcijosKnygosPage _pegasasPegasoKolekcijosKnygosPage;
        public static ParduotuvePegasasKuprinesSectionPage _pegasasPegasoKuprinesPage;
        public static ParduotuvePegasasShoppingCartPage _pegasasPegasoShoppingCartPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = CustomDriver.GetChromeDriver();
            _dropDownPage = new SelectDropDownDemoPage(driver);
            _pegasasHomePage = new ParduotuvePegasasHomePage(driver);
            _pegasasLogInPage = new ParduotuvePegasasLogInPage(driver);
            _pegasasPegasoKolekcijosKnygosPage = new ParduotuvePegasasPegasoKolekcijosKnygosPage(driver);
            _pegasasPegasoKuprinesPage = new ParduotuvePegasasKuprinesSectionPage(driver);
            _pegasasPegasoShoppingCartPage = new ParduotuvePegasasShoppingCartPage(driver);


            string email = "ona.onute89@gmail.com";
            string password = "Ona.onute123";
            _pegasasHomePage.NavigateToDefaultPage()
                .AcceptCookie()
                //.PopUp1Close()
                .ClickPrisijungti();
            _pegasasLogInPage.LogInInfoInput(email, password)
                .LogInButtonClick();
            //_pegasasHomePage.PopUp2Close();
        }

        [TearDown]
        public static void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenShot.MakeScreenShot(driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit(); //kad nebepriklausytu nuo puslapio (ne _page.Close...)
        }

    }
}

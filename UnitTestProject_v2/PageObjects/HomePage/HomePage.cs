using OpenQA.Selenium;
using System.Threading;
using UnitTestProject1.Controls;
using UnitTestProject1.PageObjects.HomePage.input;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.HomePage
{
    public class HomePage
    {
        public IWebDriver driver;
        public HomeItemControl homeItemControl;
        public HomePage(IWebDriver browser)
        {
            driver = browser;
            homeItemControl = new HomeItemControl(driver);
        }

        private By DescoperaProduseleNoastre = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/shop-online/'] > span");
        public IWebElement BtnDescopera => driver.FindElement(DescoperaProduseleNoastre);

        private By VeziMaiMulteDetalii = By.CssSelector("a[class='elementor-button-link elementor-button elementor-size-md']");
        public IWebElement BtnVezi => driver.FindElement(VeziMaiMulteDetalii);

        private By Nume = By.CssSelector("input[id='form-field-nume']");
        public IWebElement TextNume => driver.FindElement(Nume);

        private By Telefon = By.CssSelector("input[id='form-field-telefon']");
        public IWebElement TextTelefon => driver.FindElement(Telefon);

        private By Email = By.CssSelector("input[id='form-field-email']");
        public IWebElement TextEmail => driver.FindElement(Email);

        private By Data = By.CssSelector("input[id='form-field-dataevenimentului']");
        public IWebElement TextData => driver.FindElement(Data);

        private By NrPersoane = By.CssSelector("textarea[id='form-field-nrpersoane']");
        public IWebElement TextNrPersoane => driver.FindElement(NrPersoane);

        private By Locatia = By.CssSelector("textarea[id='form-field-locatiaevenimentului']");
        public IWebElement TextLocatia => driver.FindElement(Locatia);

        private By Send = By.CssSelector("button[class='elementor-button elementor-size-lg']");
        public IWebElement BtnSend => driver.FindElement(Send);

        private By Result = By.CssSelector("div[class='elementor-message elementor-message-success']");

      

        public IWebElement LblResult => driver.FindElement(Result);

        public void PressDiscover()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, DescoperaProduseleNoastre);
            BtnDescopera.Click();
        }

     

        public void PressSeeMore()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, VeziMaiMulteDetalii);
            BtnVezi.Click();
        }

        public void SendNoteInputs(SendNoteBo inputData)
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Nume);
            TextNume.SendKeys(inputData.Nume);
            TextEmail.SendKeys(inputData.Email);
            TextTelefon.SendKeys(inputData.Telefon);
            TextData.SendKeys(inputData.Data);
            TextNrPersoane.SendKeys(inputData.NrPersoane);
            TextNrPersoane.Click();
            TextLocatia.SendKeys(inputData.Locatia);
            BtnSend.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, Result);
        }
    }


}

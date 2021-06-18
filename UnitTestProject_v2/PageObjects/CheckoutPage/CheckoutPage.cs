using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Utils;
using OpenQA.Selenium;
using UnitTestProject1.PageObjects.HomePage.input;

namespace UnitTestProject1.PageObjects.CheckoutPage
{
    public class CheckoutPage
    {
        public IWebDriver driver;
        public CheckoutPage(IWebDriver browser)
        {
            driver = browser;

        }

        private By FirstName = By.CssSelector("input[id='billing_first_name']");
        public IWebElement TextFirstName => driver.FindElement(FirstName);

        private By LastName = By.CssSelector("input[id='billing_last_name']");
        public IWebElement TextLastName => driver.FindElement(LastName);

        private By PhoneNumber = By.CssSelector("input[id='billing_phone']");
        public IWebElement TextPhoneNumber => driver.FindElement(PhoneNumber);

        private By Email = By.CssSelector("input[id='billing_email']");
        public IWebElement TextEmail => driver.FindElement(Email);

        private By Address = By.CssSelector("input[id='billing_address_1']");
        public IWebElement TextAddress => driver.FindElement(Address);


        // Selector for NumeFirma Field
        private By NumeFirma = By.CssSelector("#nume_firma_field");
        public IWebElement ParaNumeFirma => driver.FindElement(NumeFirma);

        // Selector for Persoana fizica
        private By PersoanaFizica = By.CssSelector("#persoana_91");
        public IWebElement ChkPersoanaFizica => driver.FindElement(PersoanaFizica);

        // Selector for Persoana juridica
        private By PersoanaJuridica = By.CssSelector("#persoana_92");
        public IWebElement ChkPersoanaJuridica => driver.FindElement(PersoanaJuridica);

        // Selector for Total Price
        private By TotalPrice = By.CssSelector("tr.order-total td");
        public IWebElement TextTotalPrice => driver.FindElement(TotalPrice);

        // Selector for Note Comanda
        private By NoteComanda = By.CssSelector("#order_comments");
        public IWebElement TextareaNoteComanda => driver.FindElement(NoteComanda);

        //private By DeliveryDate = By.CssSelector("input[id='delivery_date']");
        //public IWebElement TextDeliveryDate => driver.FindElement(DeliveryDate);


        //private By DeliveryTime = By.CssSelector("input[id='delivery_time']");
        //public IWebElement TextDeliveryTime => driver.FindElement(DeliveryTime);

        public void ChangeToPersoanaFizica()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, PersoanaFizica);
            ChkPersoanaFizica.Click();
        }

        public void ChangeToPersoanaJuridica()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, PersoanaJuridica);
            ChkPersoanaJuridica.Click();
        }

        // This function returns if the Paragraph is displayed or not
        public bool CheckIfFirmaParagraphIsDisplayed()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, NumeFirma);
            return ParaNumeFirma.GetAttribute("style") != "display: none;";
        }

        public string TotalPriceCheckout()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, TotalPrice);
            return TextTotalPrice.Text;
        }

        public void SendNoteComandaInputs(NoteComandaBo inputData)
        {
            WaitHelpers.WaitForElementToBeVisible(driver, NoteComanda);
            TextareaNoteComanda.SendKeys(inputData.Input);
            WaitHelpers.WaitForElementValueToChangeTo(driver, NoteComanda, inputData.Input.Substring(0,20));
        }

        public string NoteComandaText()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, NoteComanda);
            return TextareaNoteComanda.GetAttribute("value");
        }
    }
}

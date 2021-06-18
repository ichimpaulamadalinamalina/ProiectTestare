using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Controls;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.ContactPage
{
    public class ContactPage
    {
        public IWebDriver driver;
        public ContactPage(IWebDriver browser)
        {
            driver = browser;
        }

        // Selector for Client and Furnizor buttons
        private By Client_Furnizor = By.CssSelector("ul.eael-tab-top-icon li");
        // client button
        public IWebElement BtnClient => driver.FindElements(Client_Furnizor)[0];
        // Furnizor button
        public IWebElement BtnFurnizor => driver.FindElements(Client_Furnizor)[1];

        // Selector for client label
        private By ClientLabel = By.CssSelector("label[for=form-field-mesaj]");
        public IWebElement LblClient => driver.FindElement(ClientLabel);

        // Selector for furnizor label
        private By FurnizorLabel = By.CssSelector("label[for=form-field-colab]");
        public IWebElement LblFurnizor => driver.FindElement(FurnizorLabel);

        // Selector for the list of locations
        private By ContactLocations = By.CssSelector("div[data-id='1cc88b6'] div.elementor-widget-wrap > div.elementor-element:not([data-id='30bb301'])");
        public IList<IWebElement> ListContactLocations => driver.FindElements(ContactLocations); 

        public void ClientButtonClick()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Client_Furnizor);
            BtnClient.Click();
        }

        public void FurnizorButtonClick()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Client_Furnizor);
            BtnFurnizor.Click();
        }

        public string GetColabStringIfVisible()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, FurnizorLabel);
            return LblFurnizor.Text;
        }
        public string GetClientStringIfVisible()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, ClientLabel);
            return LblClient.Text;
        }

        public int CountContactLocations()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, ContactLocations);
            return ListContactLocations.Count();
        }


    }
}

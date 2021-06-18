using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Controls;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.CartPage
{
    public class CartPage
    {
        public IWebDriver driver;
        public CartItemControl cartItemControl;

        public CartPage(IWebDriver browser)
        {
            driver = browser;
            cartItemControl = new CartItemControl(driver);
        }

        private By List = By.CssSelector("a[id=elementor-menu-cart__toggle_button]");
        public IWebElement BtnList => driver.FindElement(List);

        private By SeeCart = By.CssSelector("span [class=elementor-button-text]");
        public IWebElement BtnSeeCart => driver.FindElement(SeeCart);

        private By Quantity = By.CssSelector("td.product-quantity input[type=number][class=spq_qty]");
        public By Update= By.CssSelector("td.actions button.button[type=submit]");
        public IWebElement BtnUpdate => driver.FindElement(Update);
        public IWebElement TextQuantity => driver.FindElement(Quantity);
        private By Price = By.CssSelector("td.product-subtotal");
        public IWebElement TextPrice => driver.FindElement(Price);

        private By TotalPrice = By.CssSelector("td[data-title=Total]");
        public IWebElement TextTotalPrice => driver.FindElement(TotalPrice);

        public CartPage NavigateToCartPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, List);
            BtnList.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, SeeCart);
            BtnSeeCart.Click();
            return new CartPage(driver);

        }
        public void BasketCounterChange()
        {
        
            WaitHelpers.WaitForElementToBeVisible(driver, Quantity);
            TextQuantity.Clear();
            WaitHelpers.WaitForElementToBeVisible(driver, Update);
            TextQuantity.SendKeys("4");
            BtnUpdate.Click();

        }
        public string PriceCart()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Price);
            return TextPrice.Text;

        }
        public string TotalPriceCart()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, TotalPrice);
            return TextTotalPrice.Text;
        }

        public void WaitForPriceCartToChangeTo(string expectedChangedText)
        {
            WaitHelpers.WaitForElementInnerTextToChangeTo(driver, Price, expectedChangedText);
        }
    }
}

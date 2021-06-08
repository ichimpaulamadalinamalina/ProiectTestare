using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.Controls;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.ShopPage
{
    public class ShopPage
    {
        public IWebDriver driver;
        public ShopItemControl shopItemControl;
        public ShopPage(IWebDriver browser)
        {
            driver = browser;
            shopItemControl = new ShopItemControl(driver);
        }

        private By Basket = By.CssSelector("a[id=elementor-menu-cart__toggle_button]");
        public IWebElement BtnBasket => driver.FindElement(Basket);

        private By TortHora = By.CssSelector("a[data-product_id='25168']");

        public IWebElement BtnAddTortHora => driver.FindElement(TortHora);


        private By NrProductsBasket = By.CssSelector("span[class=elementor-button-icon]");
        public IWebElement TextNrProductsBasket => driver.FindElement(NrProductsBasket);

        private By EmptyMessage = By.CssSelector("div [class=woocommerce-mini-cart__empty-message]");

        public IWebElement TextEmptyMessage => driver.FindElement(EmptyMessage);


        private By Product = By.CssSelector("div[data-title=Product]");

        private By ProductAddedMessage = By.CssSelector("span[data-counter='1']");

        public IWebElement TextProductAddedMessage => driver.FindElement(ProductAddedMessage);

        private By Cross = By.CssSelector("a[aria-label='Remove this item']");

        public IWebElement BtnCross => driver.FindElement(Cross);

        private By ProductRemovedMessage = By.CssSelector("span[data-counter='0']");

        public IWebElement TextProductRemovedMessage => driver.FindElement(ProductRemovedMessage);

        private By Expanded = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/product/tort-hora-inima/']");

        public IWebElement TextExpanded => driver.FindElement(Expanded);
        public IWebElement BasketCounter()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Basket);
            return TextNrProductsBasket;
        }
        public void AddProduct()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, TortHora);
            BtnAddTortHora.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, ProductAddedMessage);
        }
        public void RemoveProduct()
        {
            BtnBasket.Click();
            WaitHelpers.WaitForElementToBeSelected(driver, Expanded);
            BtnCross.Click();
        }

    }
}

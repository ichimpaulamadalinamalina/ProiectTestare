using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using UnitTestProject1.PageObjects.ShopPage;
using UnitTestProject1.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;
        public MenuItemControl (IWebDriver browser)
        {
            driver = browser;
        }

        private By Home = By.CssSelector("a[class=elementor-item elementor-item-active]");
        public IWebElement BtnHome => driver.FindElement(Home);

    }
    public class HomeItemControl : MenuItemControl
    {
        public HomeItemControl(IWebDriver browser) : base(browser)
        {
        }

        private By Shop = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/shop-online/']");
        public IWebElement BtnShop => driver.FindElement(Shop);

        public ShopPage NavigateToShopPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Shop);
            BtnShop.Click();
            return new ShopPage(driver);
        }

    }
    public class ShopItemControl : MenuItemControl
    {
        public ShopItemControl(IWebDriver browser):base(browser)
        {
        }

    }

}

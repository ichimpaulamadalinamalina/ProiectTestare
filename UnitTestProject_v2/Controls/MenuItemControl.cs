using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using UnitTestProject1.PageObjects.BlogPage;
using UnitTestProject1.PageObjects.CandyPage;
using UnitTestProject1.PageObjects.CartPage;
using UnitTestProject1.PageObjects.CheckoutPage;
using UnitTestProject1.PageObjects.ContactPage;
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

        // Selector for the Shop button
        private By Shop = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/shop-online/']");
        public IWebElement BtnShop => driver.FindElement(Shop);

        // Selector for the Shop button
        private By CartToggle = By.CssSelector("a#elementor-menu-cart__toggle_button");
        public IWebElement BtnCartToggle => driver.FindElement(CartToggle);

        // Selector for the candy bar button
        private By CandyBar = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/candy-bar/']");
        public IWebElement BtnCandy => driver.FindElement(CandyBar);

        // Selector for the Blog button
        private By Blog = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/blogul-moldovencei/']");
        public IWebElement BtnBlog => driver.FindElement(Blog);

        // Selector for the Contact button
        private By Contact = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/contact/']");
        public IWebElement BtnContact => driver.FindElement(Contact);

        // Selector for the cart button
        private By Cart = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/cart/']");
        public IWebElement BtnCart => driver.FindElement(Cart);

        public ShopPage NavigateToShopPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Shop);
            BtnShop.Click();
            return new ShopPage(driver);
        }

        public CandyBarPage NavigateToOffertPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, CandyBar);
            BtnCandy.Click();
            return new CandyBarPage(driver);
        }

        public CartPage NavigateToCartPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Cart);
            BtnCart.Click();
            return new CartPage(driver);
        }

        public BlogulMoldovenceiPage NavigateToBlogPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Blog);
            BtnBlog.Click();
            return new BlogulMoldovenceiPage(driver);
        }
        public ContactPage NavigateToContactPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Contact);
            BtnContact.Click();
            return new ContactPage(driver);
        }

        public void ToggleCartWindow()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, CartToggle);
            BtnCartToggle.Click();
        }

    }
    public class ShopItemControl : MenuItemControl
    {
        public ShopItemControl(IWebDriver browser):base(browser)
        {
        }
    }


    public class CartItemControl : MenuItemControl
    {
        public CartItemControl(IWebDriver browser) : base(browser)
        {
        }

        // Selector for the Contact button
        private By Checkout = By.CssSelector("a.checkout-button[href='https://cuptorulmoldovencei.ro/checkout/']");
        public IWebElement btnCheckout => driver.FindElement(Checkout);

        public CheckoutPage NavigateToCheckoutPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Checkout);
            btnCheckout.Click();
            return new CheckoutPage(driver);
        }

    }



}

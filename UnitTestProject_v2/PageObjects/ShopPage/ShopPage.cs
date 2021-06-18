
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

        IJavaScriptExecutor executor;
        public ShopPage(IWebDriver browser)
        {
            driver = browser;
            shopItemControl = new ShopItemControl(driver);
            executor = (IJavaScriptExecutor)driver;
        }

        private By TorturiCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/07/Asset-9bbb.svg']");
        public IWebElement BtnTorturi => driver.FindElement(TorturiCategory);

        private By LaBucataCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/07/nnnabc.svg']");
        public IWebElement BtnLaBucata => driver.FindElement(LaBucataCategory);

        private By MiniCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/07/Asset-8bbb.svg']");
        public IWebElement BtnMini => driver.FindElement(MiniCategory);

        private By CopturiCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/09/Asset-10.svg']");
        public IWebElement BtnCopturi => driver.FindElement(CopturiCategory);

        private By PlacinteCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/09/Asset-12.svg']");
        public IWebElement BtnPlacinte => driver.FindElement(PlacinteCategory);

        private By SezonCategory = By.CssSelector("li > img[src= 'https://cuptorulmoldovencei.ro/wp-content/uploads/2020/09/Asset-11.svg']");
        public IWebElement BtnSezon => driver.FindElement(SezonCategory);

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

        private By Cross = By.CssSelector("body > div.elementor.elementor-67.elementor-location-header > div > section.elementor-section.elementor-top-section.elementor-element.elementor-element-1d7c8f8.elementor-hidden-phone.elementor-section-height-min-height.elementor-hidden-tablet.elementor-section-boxed.elementor-section-height-default.elementor-section-items-middle.elementor-sticky.elementor-sticky--active.elementor-section--handles-inside > div > div > div.elementor-column.elementor-col-25.elementor-top-column.elementor-element.elementor-element-95eddc0 > div > div > div > div > div > div.elementor-menu-cart__container.elementor-lightbox.elementor-menu-cart--shown > div > div.widget_shopping_cart_content > div.elementor-menu-cart__products.woocommerce-mini-cart.cart.woocommerce-cart-form__contents > div > div.elementor-menu-cart__product-remove.product-remove > a");

        public IWebElement BtnCross => driver.FindElement(Cross);

        private By ProductRemovedMessage = By.CssSelector("span[data-counter='0']");

        public IWebElement TextProductRemovedMessage => driver.FindElement(ProductRemovedMessage);

        private By Expanded = By.CssSelector("a[href='https://cuptorulmoldovencei.ro/product/tort-hora-inima/']");

        public IWebElement TextExpanded => driver.FindElement(Expanded);

        private By NrItemCategorySweets = By.CssSelector("ul.eael-tab-inline-icon li");

        public IList<IWebElement> ListProductsCategorySweets => driver.FindElements(NrItemCategorySweets);

        private By ListCart = By.CssSelector("a[id=elementor-menu-cart__toggle_button]");
        public IWebElement BtnCart => driver.FindElement(ListCart);
        private By Smetanic = By.CssSelector("a[data-product_id='21861']");

        public IWebElement BtnAddSmetanic => driver.FindElement(Smetanic);
        public void PressCart()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, ListCart);
            BtnCart.Click();
        }
        public IWebElement BasketCounter()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, Basket);
            return TextNrProductsBasket;
        }

   
        public int MenuCounter()
        {
            return ListProductsCategorySweets.Count();
        }
        public void AddProduct()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, TortHora);
            BtnAddTortHora.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, ProductAddedMessage);
        }
        public void AddProductSmetanic()
        {
            BtnLaBucata.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, Smetanic);
            BtnAddSmetanic.Click();
            WaitHelpers.WaitForElementToBeVisible(driver, ProductAddedMessage);
        }
        public void RemoveProduct()
        {
            BtnBasket.Click();
            WaitHelpers.WaitForElementToBeSelected(driver, Expanded);
            executor.ExecuteScript("arguments[0].click();", BtnCross);
        }

    }
}
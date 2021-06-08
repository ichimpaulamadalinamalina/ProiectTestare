
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UnitTestProject1.Controls;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.ShopPage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class AddProductTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ShopPage shopPage;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;
            shopPage = menuItemControl.NavigateToShopPage();


        }
        [TestMethod]
        public void Product_Should_Be_Removed()
        {
            Assert.AreEqual("0", shopPage.BasketCounter().GetAttribute("data-counter"));
            shopPage.AddProduct();
            Assert.AreEqual("1", shopPage.BasketCounter().GetAttribute("data-counter"));
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

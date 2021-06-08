
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using UnitTestProject1.Controls;
using UnitTestProject1.PageObjects.HomePage;
using UnitTestProject1.PageObjects.HomePage.input;
using UnitTestProject1.PageObjects.ShopPage;
using UnitTestProject1.Utils;

namespace UnitTestProject1
{
    [TestClass]
    public class SendNoteTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cuptorulmoldovencei.ro/");
            homePage = new HomePage(driver);
            var menuItemControl = homePage.homeItemControl;


        }
        [TestMethod]
        public void SendNote()
        {
            var inputData = new SendNoteBo();
            homePage.SendNoteInputs(inputData);
            Assert.AreEqual("Formularul a fost trimis cu succes!", homePage.LblResult.Text);

        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

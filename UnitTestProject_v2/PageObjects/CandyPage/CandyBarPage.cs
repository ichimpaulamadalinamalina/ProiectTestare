using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Controls;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.CandyPage
{
    public class CandyBarPage
    {
        public IWebDriver driver;
     
        public CandyBarPage(IWebDriver browser)
        {
            driver = browser;
           
        }

        private By List = By.CssSelector("span[class=elementor-button-text]");
        public IWebElement BtnList => driver.FindElement(List);

        // Selector for the first offer button
        private By MicOffer = By.CssSelector("a[href='#elementor-action%3Aaction%3Dpopup%3Aopen%26settings%3DeyJpZCI6Ijk1NyIsInRvZ2dsZSI6ZmFsc2V9']");
        public IWebElement BtnMicOffer => driver.FindElement(MicOffer);


        // Selector for the second offer button
        private By PovesteOffer = By.CssSelector("a[href='#elementor-action%3Aaction%3Dpopup%3Aopen%26settings%3DeyJpZCI6Ijk2MCIsInRvZ2dsZSI6ZmFsc2V9']");
        public IWebElement BtnPovesteOffer => driver.FindElement(PovesteOffer);


        // Selector for the third offer button
        private By TraditionalOffer = By.CssSelector("a[href='#elementor-action%3Aaction%3Dpopup%3Aopen%26settings%3DeyJpZCI6IjkzMSIsInRvZ2dsZSI6ZmFsc2V9']");
        public IWebElement BtnTraditionalOffer => driver.FindElement(TraditionalOffer);

        public CandyBarPage NavigateToOffertPage()
        {
            WaitHelpers.WaitForElementToBeVisible(driver, List);
            BtnList.Click();
            return new CandyBarPage(driver);
        }
    }
}

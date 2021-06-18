using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObjects.BlogPage
{
    public class BlogulMoldovenceiPage
    {
        public IWebDriver driver;
        public BlogulMoldovenceiPage(IWebDriver browser)
        {
            driver = browser;
        }

        // Selector for the add more button
        private By ShowMore = By.CssSelector("#eael-load-more-btn-76ec15b2");
        public IWebElement BtnAdaugaMaiMulte => driver.FindElement(ShowMore);

        // Selector fot the Show More button content text
        private By ShowMoreContent = By.CssSelector("#eael-load-more-btn-76ec15b2 span");
        public IWebElement SpanAdaugaMaiMulte => driver.FindElement(ShowMoreContent);


        // Selector for all link elements that are not hidden
        private By ActiveLinks = By.CssSelector("div.eael-grid-post-holder i+a");
        public IList<IWebElement> ListBlogLinks => driver.FindElements(ActiveLinks);

        // Get the number of visible Links
        public int GetNumberOfVisibleLinks()
        {
            WaitHelpers.WaitForElementTextToChangeTo(driver, SpanAdaugaMaiMulte, "ARATĂ MAI MULTE");
            return ListBlogLinks.Count();
        }

        // Checks if a "Show more" button exists
        public bool ShowMoreButtonExists()
        {
            bool val;
            try
            {
                val = BtnAdaugaMaiMulte.Displayed;
            }
            catch
            {
                val = false;
            }
            return val;
        }

        public void PressShowMore()
        {
            // Wait for button to be visible
            WaitHelpers.WaitForElementToBeVisible(driver, ShowMore);
            BtnAdaugaMaiMulte.Click();
        }


    }
}

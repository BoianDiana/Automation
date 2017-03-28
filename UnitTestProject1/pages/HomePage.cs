using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.pages
{
    class HomePage
    {

        IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        // constants
        String title = "Welcome to the Docler Holding QA Department";
        String subtitle = "This site is dedicated to perform some exercises and demonstrate automated web testing.";

        // elements
        [FindsBy(How = How.Id, Using = "home")]
        public IWebElement homeButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "ui-test")]
        public IWebElement textContainer { get; set; }



        // methods
        public void clickOnHomeButton(IWebDriver driver)
        {
            homeButton.Click();

        }

        // Check if home button is enable
        public Boolean getHomeButtonStatus(IWebDriver driver)
        {
            return homeButton.Enabled;
        }

        //Check if title is displayed
        public Boolean getTitleVisiblity(IWebDriver driver)
        {
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            return helperMethods.getTextVisiblity(driver, title);

        }

        // Check if subtitle is displayed
        public Boolean getSubTitleVisibility(IWebDriver driver)
        {
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            return helperMethods.getTextVisiblity(driver, subtitle);

        }

        //Method used to get the text that is displayed as header on the page
        public String getTextDisplayedWithDesiredFormat(IWebDriver driver, String format)
        {
            By css = By.CssSelector(format);
            IWebElement element = driver.FindElement(css);
            String text = element.Text;

            return text;
        }

        // Check if title is displayed as expected regarding the format
        public Boolean checkIsTitleDisplayedAsHeader(IWebDriver driver)
        {

            String textAsHeader = getTextDisplayedWithDesiredFormat(driver, "div.ui-test>h1");

            System.Diagnostics.Debug.WriteLine("Like Header: " + textAsHeader);
            return title.Equals(textAsHeader);
        }

        // Check if subtitle is displayed as expected regarding the format
        public Boolean checkIsSubtitleDisplayedAsParagraph(IWebDriver driver)
        {

            String textAsParagraph = getTextDisplayedWithDesiredFormat(driver, "div.ui-test>p.lead");

            System.Diagnostics.Debug.WriteLine("Like paragraph: " + textAsParagraph);

            return subtitle.Equals(textAsParagraph);
        }



    }
}

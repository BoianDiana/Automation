using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.pages
{
    class UITestingPage
    {
        IWebDriver driver;

        public UITestingPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        // elements
        [FindsBy(How = How.Id, Using = "site")]
        public IWebElement uiTestingButton { get; set; }


        // methods
        public void clickOnUITestingButton(IWebDriver driver)
        {
            uiTestingButton.Click();

        }
    }
}

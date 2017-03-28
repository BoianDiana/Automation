using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.pages
{
    class ErrorPage
    {

        IWebDriver driver;

        public ErrorPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        // elements
        [FindsBy(How = How.Id, Using = "error")]
        public IWebElement errorButton { get; set; }


        // methods
        public void clickOnErrorButton(IWebDriver driver)
        {
            errorButton.Click();

        }


    }
}

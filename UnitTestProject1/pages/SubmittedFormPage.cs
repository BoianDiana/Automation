using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.pages
{
    class SubmittedFormPage
    {
         IWebDriver driver;

         public SubmittedFormPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        // elements
        [FindsBy(How = How.Id, Using = "hello-text")]
        public IWebElement helloText { get; set; }

       
    }
}

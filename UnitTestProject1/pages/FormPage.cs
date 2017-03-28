using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.pages
{
    class FormPage
    {
        IWebDriver driver;

        public FormPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        // elements
        [FindsBy(How = How.Id, Using = "form")]
        public IWebElement formButton { get; set; }
        [FindsBy(How = How.Id, Using = "hello-input")]
        public IWebElement formInput { get; set; }
        [FindsBy(How = How.Id, Using = "hello-submit")]
        public IWebElement formInputButton { get; set; }


        // methods
        public void clickOnFormButton(IWebDriver driver)
        {
            formButton.Click();

        }

        // get if button is enable 
        public Boolean getFormButtonStatus(IWebDriver driver)
        {
            return formButton.Enabled;
        }

        // check if title is displayed on page
        public Boolean getFormTitleVisiblity(IWebDriver driver)
        {
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            return helperMethods.getTextVisiblity(driver, "Simple Form Submission");

        }

        // Method used to check if both parts of form are displayed (input field and button)
        public Boolean getFormInputGroupVisibility(IWebDriver driver)
        {

            return (formInput.Displayed && formInputButton.Displayed);
        }

        // Method used to enter text and submit the form
        public String completeForm(IWebDriver driver, String stringToBeEnter)
        {
            // empty the form
            formInput.Clear();

            // enter desired value
            formInput.SendKeys(stringToBeEnter);

            // get formInput text displayed
            String textThatWasEntered = formInput.Text;

            // submit the form
            formInputButton.Submit();

            // return the text that was entered
            return textThatWasEntered;
        }


    }
}

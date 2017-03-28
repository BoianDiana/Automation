using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.helpers
{
    class HelperMethods
    {

        //---Common Helper Methods

        public Boolean getTextVisiblity(IWebDriver driver, String stringToFind)
        {
            String bodyText = driver.FindElement(By.TagName("body")).Text;
            return (bodyText.Contains(stringToFind));
        }


        //--- Home Page Helper Methods---//

        // Method used to check if Home page is displayed
        public void checkHomePageIsDisplayed(IWebDriver driver)
        {
            UnitTestProject1.pages.HomePage homePage = new pages.HomePage(driver);

            // check if title is displayed
            Assert.IsTrue(homePage.getTitleVisiblity(driver), "Desired Title is not displayed on Home Page");

            // check if subtitle is displayed
            Assert.IsTrue(homePage.getSubTitleVisibility(driver), "Desired Subtitle is not displayed on Home Page");
        }


        //--- Form Page Helper Methods---//

        // Method used to check if Form page is displayed
        public void checkFormPageIsDisplayed(IWebDriver driver)
        {
            pages.FormPage formPage = new pages.FormPage(driver);

            // check if title of form is displayed
            Assert.IsTrue(formPage.getFormTitleVisiblity(driver), "Desired Form Title is not displayed on Form Page");

            // check if form input is displayed
            Assert.IsTrue(formPage.getFormInputGroupVisibility(driver), "Input Form elements are not displayed corretly");
        }

        //Method used to check if the text enter in input filed is the expected one
        public void checkIfEnterTextIsTheCorrectOne(IWebDriver driver, String desireText)
        {
            pages.FormPage formPage = new pages.FormPage(driver);

            // get the text that was type to input field
            String textEntered = formPage.completeForm(driver, desireText);

            // check if the text is the desired one
            Assert.AreEqual(textEntered, desireText, String.Format("Your text was not introduced correctly. It was entered :% instead of :%s", textEntered, desireText));
        }

        //---Submitted Form Page Helper Methods---//

        //Method used to check if the text that was entered using the form is displayed as expected
        public void checkIfCorrectNameIsDisplayed(IWebDriver driver, String desireText)
        {
            pages.SubmittedFormPage sumittedFormPage = new pages.SubmittedFormPage(driver);

            Assert.IsTrue(sumittedFormPage.helloText.Text.Contains(desireText));

        }
    }
}

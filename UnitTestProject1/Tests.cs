using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        IWebDriver driver;
        string url = "http://uitest.duodecadits.com/";

        [TestInitialize]
        public void TestSetup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        //REQ-UI-01
        [TestMethod]
        public void checkSiteTitle()
        {
            String siteTitle = driver.Title;
            Assert.AreEqual(siteTitle, "UI Testing Site");
        }

        //REQ-UI-02
        [TestMethod]
        public void checkSiteLogo()
        {
            String headText = driver.FindElement(By.TagName("head")).Text;
            Assert.IsTrue(headText.Contains("assets/img/favicon.png"));
        }

        //REQ-UI-03
        [TestMethod]
        public void homePageDisplayed()
        {
            pages.HomePage homePage = new pages.HomePage(driver);
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            // click in Home button
            homePage.clickOnHomeButton(driver);

            // check if home page is displayed 
            helperMethods.checkHomePageIsDisplayed(driver);

        }

        ////REQ-UI-04
        [TestMethod]
        public void homePageStatus()
        {
            pages.HomePage homePage = new pages.HomePage(driver);

            // click in Home button
            homePage.clickOnHomeButton(driver);

            // check if Home button has active status
            Assert.IsTrue(homePage.getHomeButtonStatus(driver), String.Format("Actual status of Home button is:%s", homePage.getHomeButtonStatus(driver)));

        }

        //REQ-UI-05
        [TestMethod]
        public void formPageDisplayed()
        {
            pages.FormPage formPage = new pages.FormPage(driver);
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            // click in Form button
            formPage.clickOnFormButton(driver);

            // check if form page is displayed 
            helperMethods.checkFormPageIsDisplayed(driver);

        }

        //REQ-UI-06
        [TestMethod]
        public void formPageStatus()
        {
            pages.FormPage formPage = new pages.FormPage(driver);

            // click in Form button
            formPage.clickOnFormButton(driver);

            // check if Form button has active status
            Assert.IsTrue(formPage.getFormButtonStatus(driver), String.Format("Actual status of Form button is:%s", formPage.getFormButtonStatus(driver)));

        }

        //REQ-UI-07
        [TestMethod]
        public void errorResponseCode()
        {
            pages.ErrorPage errorPage = new pages.ErrorPage(driver);
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            // click in Error button
            errorPage.clickOnErrorButton(driver);

            // check if 404 is displayed as response code
            Assert.IsTrue(helperMethods.getTextVisiblity(driver, "404"));
        }

        //REQ-UI-08
        [TestMethod]
        public void uiTestingClickingEffect()
        {
            pages.UITestingPage uiTesting = new pages.UITestingPage(driver);
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            // click on Ui testing button
            uiTesting.clickOnUITestingButton(driver);

            // check if Home page is displayed
            helperMethods.checkHomePageIsDisplayed(driver);

        }

        //REQ-UI-09
        [TestMethod]
        public void homePageTitleFormat()
        {

            pages.HomePage homePage = new pages.HomePage(driver);

            // click in Home button
            homePage.clickOnHomeButton(driver);

            // check if desired text is displayed as header ( having h1 tag)
            Assert.IsTrue(homePage.checkIsTitleDisplayedAsHeader(driver), "Ooops, not desired text displayed as header");


        }

        //REQ-UI-10
        [TestMethod]
        public void homePageSubtitleFormat()
        {
            pages.HomePage homePage = new pages.HomePage(driver);

            // click in Home button
            homePage.clickOnHomeButton(driver);

            // check if desired text is displayed as paragraph ( having p tag)
            Assert.IsTrue(homePage.checkIsSubtitleDisplayedAsParagraph(driver), "Something is not like you are execting for this paragraph, Sorry :( ");
        }

        //REQ-UI-11
        [TestMethod]
        public void formPageDisplayedElements()
        {
            pages.FormPage formPage = new pages.FormPage(driver);
            helpers.HelperMethods helperMethods = new helpers.HelperMethods();

            // click in Form button
            formPage.clickOnFormButton(driver);

            // check that input form and submitt button is displayed
            Assert.IsTrue(formPage.getFormInputGroupVisibility(driver));
        }

        //REQ-UI-12
        public void submitForm()
        {
            pages.FormPage formPage = new pages.FormPage(driver);
            helpers.HelperMethods helpersMethods = new helpers.HelperMethods();

            //click on Form button
            formPage.clickOnFormButton(driver);

            // check if desired text was sent throught input form
            helpersMethods.checkIfEnterTextIsTheCorrectOne(driver, "Emily");

            // check if the name is dislayed as wanted
            helpersMethods.checkIfCorrectNameIsDisplayed(driver, "Emily");

        }
    }
}


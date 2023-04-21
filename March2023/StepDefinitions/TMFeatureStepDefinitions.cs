
using March2023.Pages;
using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace March2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        TMPage tMpageObj = new TMPage();

        [Given(@"I am logged in to TurnUp portal")]
        public void GivenIAmLoggedInToTurnUpPortal()
        {
            driver = new ChromeDriver();

            Login loginObj = new Login();
            loginObj.login(driver);

        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            Dashboard dashboardObj = new Dashboard();
            dashboardObj.GoToTMPage(driver);
        }

        [When(@"Create a new Time and Material record")]
        public void WhenCreateANewTimeAndMaterialRecord()
        {
            tMpageObj.Create(driver);
        }

        [Then(@"New record should be created successfully")]
        public void ThenNewRecordShouldBeCreatedSuccessfully()
        {
           
            string latestCreated = tMpageObj.ValidateNewRecord(driver);

            Assert.That(latestCreated == "TimeTest", "Actual code and expected code do not match");

            driver.Quit(); 

        }


        [When(@"Update the '([^']*)', '([^']*)' and '([^']*)' on existing record")]
        public void WhenUpdateTheAndOnExistingRecord(string description, string code, string price)
        {
            tMpageObj.Edit(driver, description, code, price);
        }



        [Then(@"the record should show updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldShowUpdatedCdAnd(string description, string code, string price)
        {
            string editedDescription = tMpageObj.ValidateEditedDescription(driver);
            string editedCode = tMpageObj.validateEditedCode(driver);
            string editedPrice = tMpageObj.validateEditedPrice(driver);

            Assert.That(editedDescription == description, "Could not edit description");
            Assert.That(editedCode == code, "Could not edit code");
            Assert.That(editedPrice == price, "Could not edit price");
            driver.Quit();
        }

        [When(@"Delete the record")]
        public void WhenDeleteTheRecord()
        {
           tMpageObj.Delete(driver);
        }

        [Then(@"The record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
           string lastRecord = tMpageObj.ValidateRecordDeletion(driver);
            Assert.That(lastRecord != "desc3", "Could not delete");
            driver.Quit();
        }

    }
}

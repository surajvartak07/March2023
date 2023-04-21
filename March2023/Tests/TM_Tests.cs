
using March2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using March2023.Utilities;

namespace March2023.Tests
{
    [TestFixture]
   [Parallelizable]
    public class TM_Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            Login loginObj = new Login();
            loginObj.login(driver);


            Dashboard dashboardObj = new Dashboard();
            dashboardObj.GoToTMPage(driver);
        }

        [Test, Order(1)]
        public void CreateTM_Test()
        {
            TMPage tMObj = new TMPage();
            tMObj.Create(driver);

          string latestCreated = tMObj.ValidateNewRecord(driver);
            Assert.That(latestCreated == "TimeTest", "Actual code and expected code do not match");


        }
        [Test, Order(2)]
        public void EditTM_Test()
        {
            TMPage tMObj = new TMPage();
            tMObj.Edit(driver);
        }

        [Test, Order(3)]
        public void DeleteTM_Test()
        {
            TMPage tMObj = new TMPage();
            tMObj.Delete(driver);
            tMObj.ValidateRecordDeletion(driver);
        }

        [TearDown]
        public void CloseTests()
        {
            driver.Quit();
        }
    }

}

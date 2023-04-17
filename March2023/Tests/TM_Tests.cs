
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
   // [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            Login loginObj = new Login();
            loginObj.login();


            Dashboard dashboardObj = new Dashboard();
            dashboardObj.GoToTMPage();
        }

        [Test, Order(1)]
        public void CreateTM_Test()
        {
            TMPage createTMObj = new TMPage();
            createTMObj.Create();
        }
        [Test, Order(2)]
        public void EditTM_Test()
        {
            TMPage editTMObj = new TMPage();
            editTMObj.Edit();
        }

        [Test, Order(3)]
        public void DeleteTM_Test()
        {
            TMPage deleteTMObj = new TMPage();
            deleteTMObj.Delete();
        }

        [TearDown]
        public void CloseTests()
        {
            driver.Quit();
        }
    }

}

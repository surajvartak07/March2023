using March2023.Pages;
using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            Login loginObj = new Login();
            loginObj.login(driver);

            Dashboard dashboardObj = new Dashboard();
            dashboardObj.GotoEmployeePage(driver);
        }

        [Test, Order(1)]
        public void CreateEmployeeTest()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.CreateEmployee(driver);
        }
        [Test, Order(2)]
        public void EditEmployeeTest() 
        {
        EmployeePage employeePageObj = new EmployeePage(); 
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(3)]
        public void DeleteEmployeeTest()
        {
        EmployeePage employeePage = new EmployeePage();
            employeePage.DeleteEmployee(driver);
        }

        [TearDown]
        public void CloseTests()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}

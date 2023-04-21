using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Pages
{
    public class EmployeePage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            IWebElement createNewButton = driver.FindElement(By.ClassName("btn")); //actual ClassName for createnewbutton is btn btn-primary but selenium doesnt support space in classname anymore so we can just use first word in classname and it searches corrextly 
            createNewButton.Click();

            IWebElement nameTextbox = driver.FindElement(By.Name("Name"));
            nameTextbox.SendKeys("CreateNewEmployee");
            
            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.SendKeys("CreateNewEmployeeUsername");
            
            IWebElement contactTextbox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextbox.SendKeys("123456789");
            
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("Employee@123");
            
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("Employee@123");
            
            IWebElement isAdminCheckbox = driver.FindElement(By.Id("IsAdmin"));
            isAdminCheckbox.Click();
            
            IWebElement groupsDropdown = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div"));
            groupsDropdown.Click();
            
            IWebElement groupOption = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[13]"));
            //Creating object of an Actions class
            Actions action = new Actions(driver);
            //Performing the mouse hover action on the target element nztest.
            action.MoveToElement(groupOption).Perform();
            groupOption.Click(); //this dropdown is built such a way that first we need to hover over the option and then click on it
            
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1000);

            //IWebElement backtoListLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            IWebElement backtoListLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backtoListLink.Click();
            Thread.Sleep(3000);

            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
            Thread.Sleep(2000);

            IWebElement latestCreated = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(latestCreated.Text == "CreateNewEmployee", "Employee could not be created");
        }

        public void EditEmployee(IWebDriver driver)
        {
            Thread.Sleep(5000);
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            IWebElement editName = driver.FindElement(By.Id("Name"));
            editName.Clear();
            editName.SendKeys("gbjfiigjjsdlkv");

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click() ;

            IWebElement backToListLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListLink.Click();
            Thread.Sleep(3000);

            IWebElement goToLastPageAgain = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageAgain.Click() ;

            IWebElement edited = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(edited.Text == "gbjfiigjjsdlkv", "Could not be edited");
        }

        public void DeleteEmployee(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageAgain = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageAgain.Click();
            Thread.Sleep(2000);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(lastRecord.Text != "gbjfiigjjsdlkv", "Could not be deleted");
        }
    }
}

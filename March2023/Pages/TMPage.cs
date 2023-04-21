using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Pages
{
    public class TMPage
    {
        public void Create(IWebDriver driver)
        {
            //Create new Time entry  

            //Find and click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //click on dropdown 
            IWebElement tmDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            tmDropdown.Click();

            Thread.Sleep(2000);

            //click on time option from dropdown 
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //enter text in code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TimeTest");

            //enter text in description textbox
            IWebElement descriptionText = driver.FindElement(By.Id("Description"));
            descriptionText.SendKeys("DescriptionTest");

            //click on price textbox to select it for entering the text because this textbox accepts value only after clicking on it once
            IWebElement priceOverlapBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlapBox.Click();
            //enter value in price tyextbox 
            IWebElement priceText = driver.FindElement(By.Id("Price"));
            priceText.SendKeys("100");


            IWebElement saveButtion = driver.FindElement(By.Id("SaveButton"));
            saveButtion.Click();

            Thread.Sleep(5000);

            //go to last page because newly added entry goes to last page last row
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
            Thread.Sleep(5000);

        }

        public string ValidateNewRecord(IWebDriver driver)
        {
            //changed tr[4] part in xpath to tr[last()] so that it always finds last entry
            IWebElement latestCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(2000);
            return latestCreated.Text;
            //checking if newly created entry exists

        }

        public void Edit(IWebDriver driver, string description = "", string code = "", string price = "")
        {
            //Go to last page because our record is on last page, in createnew we went to last page but this test is seperate so again we have to go to last page
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
            Thread.Sleep(5000);

            // Edit newly created time entry

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //IWebElement editDropdownValue = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            //editDropdownValue.Click();
            //Thread.Sleep(2000);

            ////editing dropdown value from time to material
            //IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            //materialOption.Click();

            IWebElement editCodeBox = driver.FindElement(By.Id("Code"));
            editCodeBox.Clear();
            editCodeBox.SendKeys(code);

            IWebElement editDescriptionBox = driver.FindElement(By.Id("Description"));
            editDescriptionBox.Clear();
            editDescriptionBox.SendKeys(description);

            IWebElement overlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            overlap.Click();                                   
               
            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPrice.Clear();
            overlap.Click() ;
            editPrice.SendKeys(price);
            

            Thread.Sleep(1000);

            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(5000);

            IWebElement goToLastPageAgain = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageAgain.Click();
            Thread.Sleep(5000);

        }

        public string ValidateEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }

        public string validateEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        public string validateEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }

        public void Delete(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //Go to last page because our record is on last page, in createnew we went to last page but this test is seperate so again we have to go to last page
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
            Thread.Sleep(5000);

            //Delete newly created record

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //clicking OK on popup window
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(8000);
        }

        public string ValidateRecordDeletion(IWebDriver driver)
        {
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return lastRecord.Text;
        }
    }
}

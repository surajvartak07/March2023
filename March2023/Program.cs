
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Initialised browser element called driver, navigated to URL, maximised window
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2fTimeMaterial");
driver.Manage().Window.Maximize();

//Initialised webelement UserNameTextBox, found it using ID, and entered value hari
IWebElement userNameTextBbox = driver.FindElement(By.Id("UserName"));
userNameTextBbox.SendKeys("hari");

//Initialised webelement PasswordTextbox, found it using ID, and entered value 123123
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Initialised webelement LoginButton,found it using Xpath, and clicked on it
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

//Initialised webelement HelloHari, found it using Xpath, and checked if it contains the text Hello hari
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User Logged in successfully");
}
else
{
    Console.WriteLine("Login failed");
}

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

Thread.Sleep(2000);

//go to last page because newly added entry goes to last page last row
IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPage.Click();
Thread.Sleep(2000);

//changed tr[4] part in xpath to tr[last()] so that it always finds last entry
IWebElement latestCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

//checking if newly created entry exists
if (latestCreated.Text == "TimeTest")
{
    Console.WriteLine("Created Successfully");
}
else
{
    Console.WriteLine($"Could not create");
}


// Edit newly created time entry

IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();

IWebElement editDropdownValue = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
editDropdownValue.Click();
Thread.Sleep(2000);

//editing dropdown value from time to material
IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
materialOption.Click();

IWebElement editCodeBox = driver.FindElement(By.Id("Code"));
editCodeBox.Clear();
editCodeBox.SendKeys("MaterialTestEdited");

IWebElement editDescriptionBox = driver.FindElement(By.Id("Description"));
editDescriptionBox.Clear();
editDescriptionBox.SendKeys("DescriptionTestEdited");

IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
editSaveButton.Click();
Thread.Sleep(2000);

IWebElement goToLastPageAgain = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageAgain.Click();
Thread.Sleep(2000);

IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (editedRecord.Text == "MaterialTestEdited")
{
    Console.WriteLine("Edited Successfully");
}
else
{
    Console.WriteLine("Could not edit");
}

//Delete newly created record
Thread.Sleep(2000);

IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

//clicking OK on popup window
driver.SwitchTo().Alert().Accept();
Thread.Sleep(5000);

//last record should not be 'MaterialTestEdited' because we deleted that record 
IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (lastRecord.Text == "MaterialTestEdited")
{
    Console.WriteLine("Could not delete");
}
else
{
    Console.WriteLine("Deleted successfully");
}
















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

IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

IWebElement tmDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
tmDropdown.Click();

Thread.Sleep(2000);

IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
timeOption.Click();

IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("TimeTest");

IWebElement descriptionText = driver.FindElement(By.Id("Description"));
descriptionText.SendKeys("DescriptionTest");

IWebElement priceOverlapBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceOverlapBox.Click();

IWebElement priceText = driver.FindElement(By.Id("Price"));
priceText.SendKeys("100");

IWebElement saveButtion = driver.FindElement(By.Id("SaveButton"));
saveButtion.Click();    

Thread.Sleep(2000);

IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPage.Click();

IWebElement latestCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                                                 
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
Thread.Sleep(1000);

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

IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

driver.SwitchTo().Alert().Accept();














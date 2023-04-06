
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Initialised browser element called driver, navigated to URL, maximised window
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2fTimeMaterial");
driver.Manage().Window.Maximize();

//Initialised webelement UserNameTextBox, found it using ID, and entered value hari
IWebElement UserNameTextBbox = driver.FindElement(By.Id("UserName"));
UserNameTextBbox.SendKeys("hari");

//Initialised webelement PasswordTextbox, found it using ID, and entered value 123123
IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
PasswordTextbox.SendKeys("123123");

//Initialised webelement LoginButton,found it using Xpath, and clicked on it
IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
LoginButton.Click();

//Initialised webelement HelloHari, found it using Xpath, and checked if it contains the text Hello hari
IWebElement HelloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if (HelloHari.Text == "Hello hari!")
{
    Console.WriteLine("User Logged in successfully");
}
else
{
    Console.WriteLine("Login failed");
}
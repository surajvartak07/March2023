
using March2023.CreateEditDelete;
using March2023.Dashboard;
using March2023.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Initialised browser element called driver, navigated to URL, maximised window
IWebDriver driver = new ChromeDriver();

Login loginObj = new Login();
loginObj.login(driver); 

GoToTMPage goToTMPageObj = new GoToTMPage();
goToTMPageObj.goToTMPage(driver);

CreateEditDelete createEditDeleteObj = new CreateEditDelete();
createEditDeleteObj.Create(driver);
createEditDeleteObj.Edit(driver);   
createEditDeleteObj.Delete(driver);


















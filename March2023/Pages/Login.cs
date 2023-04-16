using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Pages
{
    public class Login : CommonDriver
    {
        public void login()
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2fTimeMaterial");
            driver.Manage().Window.Maximize();
            try
            {
                //Initialised webelement UserNameTextBox, found it using ID, and entered value hari
                IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
                userNameTextBox.SendKeys("hari");
            }
            catch (Exception e)
            {
                Assert.Fail("login page hasn't loaded yet");
            }
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

        }
    }
}
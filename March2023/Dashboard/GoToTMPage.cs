﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Dashboard
{
    public class GoToTMPage
    {
        public void goToTMPage(IWebDriver driver)
        {
            //navigate to time and material page
            IWebElement adminMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminMenu.Click();

            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
            Thread.Sleep(3000);
        }
    }
}

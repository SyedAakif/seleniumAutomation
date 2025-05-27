using Automation_Project.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Project.Pages
{
    internal class LoginPage: DriverFactory
    {
        By userNameTxt = By.Id("username");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("doLogin");
        public void Login(string url, string username, string password) {
            driver.Url = url;
            driver.FindElement(userNameTxt).SendKeys(username);
            driver.FindElement(passwordTxt).SendKeys(password);
            driver.FindElement(loginBtn).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("createRoom")));
            string buttonText = driver.FindElement(By.Id("createRoom")).Text;
            Assert.AreEqual("Create", buttonText, "Login failed");
        }
    }
}

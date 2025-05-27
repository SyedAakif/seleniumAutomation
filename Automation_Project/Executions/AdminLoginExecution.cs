using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static System.Net.WebRequestMethods;
using Automation_Project.Utils;
using Automation_Project.Pages;
using Automation_Project.Pages.Admin;

namespace Automation_Project
{
    
    [TestClass]
    public class AdminLoginExecution
    {
        DriverFactory factory = new DriverFactory();
        [TestInitialize]
        public void SetUp()
        {
            factory.DriverInit();
            DriverFactory.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [TestCategory("login"), TestCategory("Positive")]
        public void TestMethod1()
        {
            //DriverFactory factory = new DriverFactory();
            //factory.DriverInit();

            LoginPage loginPage = new LoginPage();
            loginPage.Login("https://automationintesting.online/admin", "admin", "password");
            //RoomsPage roomsPage = new RoomsPage();
            //roomsPage.addRoom();
            //DriverFactory.driver.Quit();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DriverFactory.driver.Quit();
        }

        //[TestMethod]
        //public void TestMethod2() { 
        //    RoomsPage roomsPage = new RoomsPage();
        //    roomsPage.addRoom();
        //}
        //[TestMethod]
        //[TestCategory("login"), TestCategory("Negative")]
        //public void TestMethod2()
        //{
        //    IWebDriver driver = new ChromeDriver();

        //    driver.Url = "https://automationintesting.online/admin";
        //    driver.FindElement(By.Id("username")).SendKeys("admin12");
        //    driver.FindElement(By.Id("password")).SendKeys("test");
        //    driver.FindElement(By.Id("doLogin")).Click();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert")));
        //    string aleartText = driver.FindElement(By.ClassName("alert")).Text;
        //    Assert.AreEqual("Invalid credentials", aleartText, "Login failed");
        //    driver.Quit();
        //}
    }
}

using Automation_Project.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Project.Pages.Admin
{
    internal class RoomsPage:DriverFactory
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        string newRoomId = null;
        #region Locators
        By roomId = By.Id("roomName");
        By roomTypeDropDown = By.Id("type");
        By accessible = By.Id("accessible");
        By price = By.Id("roomPrice");
        By wifiCheckbox = By.Id("wifiCheckbox");
        By tvCheckbox = By.Id("tvCheckbox");
        By radioCheckbox = By.Id("radioCheckbox");
        By refreshCheckbox = By.Id("refreshCheckbox");
        By safeCheckbox = By.Id("safeCheckbox");
        By viewsCheckbox = By.Id("viewsCheckbox");
        By createRoomBtn = By.Id("createRoom");
        #endregion
        public void AddRoom()
        {
            string roomNumber = "105";
            driver.Url = "https://automationintesting.online/admin/rooms";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("createRoom")));
            InputField(roomId, roomNumber); //driver.FindElement(roomId).SendKeys("105");
            SelectDropdown(roomTypeDropDown, "Double");
            SelectDropdown(accessible, "true");
            InputField(price, "200");
            Checkbox(wifiCheckbox, true);
            Checkbox(tvCheckbox, false);
            Checkbox(refreshCheckbox, true);
            driver.FindElement(createRoomBtn).Click();
            

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("roomName" + roomNumber)));
            string roomName = driver.FindElement(By.Id("roomName" + roomNumber)).Text;
            Assert.AreEqual(roomNumber, roomName, "Room Creation Failed");
        }


        public void RemoveRoom()
        {
            string roomNumber = "105";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("roomName" + roomNumber)));
            IWebElement roomElement = driver.FindElement(By.XPath($"//p[text()='{roomNumber}']/ancestor::div[contains(@class, 'row')]"));
            IWebElement deleteButton = roomElement.FindElement(By.CssSelector(".roomDelete"));
            deleteButton.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("roomName" + roomNumber)));
            bool isDeleted = driver.FindElements(By.Id(roomNumber)).Count == 0;
            Assert.IsTrue(isDeleted, $"Room with ID {roomNumber} still exists after delete.");
        }

        public void RoomDetail()
        {
            string roomNumber = "103";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("roomName" + roomNumber)));
            //string roomNumber = driver.FindElement(By.Id($"roomName{roomNumber}")).Text;
            IWebElement roomElement = driver.FindElement(By.Id("roomName" + roomNumber));
            roomElement.Click();
            IWebElement roomHeading = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[starts-with(normalize-space(.), 'Room:')]")));
            string headingText = roomHeading.Text;
            bool containsExpectedNumber = headingText.Contains(roomNumber);
            Assert.IsTrue(containsExpectedNumber, $"Expected room number {roomNumber} not found in heading: {headingText}");
        }

        // ****************************
        //        Helper Functions
        // ****************************    
        private void InputField(By locator, string value)
        {
            driver.FindElement(locator).SendKeys(value);
        }
        private void SelectDropdown(By element, string text)
        {
            var dropdown = new SelectElement(driver.FindElement(element));
            dropdown.SelectByText(text);
        }

        private void Checkbox(By locator, Boolean select)
        {
            var checkbox = driver.FindElement(locator);
            if (!checkbox.Selected && select)
            {
                checkbox.Click();
            }
        }
    }
}

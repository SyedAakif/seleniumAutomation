using Automation_Project.Pages;
using Automation_Project.Pages.Admin;
using Automation_Project.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Project
{
    [TestClass]
    public class AdminRoomPagesExecution
    {
        private DriverFactory factory = new DriverFactory();

        [TestInitialize]
        public void SetUp()
        {
            factory.DriverInit();
            DriverFactory.driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage();
            loginPage.Login("https://automationintesting.online/admin", "admin", "password");
        }


        [TestMethod]
        [TestCategory("AdminRooms"), TestCategory("add-room")]
        public void TestMethod_AddRooms()
        {
            RoomsPage roomsPage = new RoomsPage();
            roomsPage.AddRoom();
        }

        [TestMethod]
        [TestCategory("AdminRooms"), TestCategory("remove-room")]
        public void TestMethod_RemoveRooms()
        {
            RoomsPage roomsPage = new RoomsPage();
            roomsPage.RemoveRoom();
        }

        [TestMethod]
        [TestCategory("AdminRooms"), TestCategory("open-room-Details")]
        public void TestMethod_OpenRoomDetails()
        {
            RoomsPage roomsPage = new RoomsPage();
            roomsPage.RoomDetail();
        }

        //[TestCleanup]
        //public void Cleanup() {
        //    DriverFactory.driver.Quit();
        //}
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Project.Utils
{
    internal class DriverFactory
    {
        public static IWebDriver driver;

        public void DriverInit()
        {
            driver = new ChromeDriver();
        }
    }
}

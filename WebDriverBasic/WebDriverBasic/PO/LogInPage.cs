using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.PO
{
    class LogInPage
    {
        private IWebDriver driver;

        private IWebElement nameInput => driver.FindElement(By.Id("Name"));
        private IWebElement passwordInput => driver.FindElement(By.Id("Password"));
        private IWebElement submitBtn => driver.FindElement(By.ClassName("btn"));

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage LogIn(string login, string password)
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.ClassName("btn")).Click();

            return new HomePage(driver);
        }
    }
}

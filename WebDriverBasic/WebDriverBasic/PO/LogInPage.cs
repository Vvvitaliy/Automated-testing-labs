using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;

namespace WebDriverBasic.po
{
    public class LogInPage
    {
        private IWebDriver driver;

        private IWebElement nameInput => driver.FindElement(By.Id("Name"));
        private IWebElement passwordInput => driver.FindElement(By.Id("Password"));
        private IWebElement submitBtn => driver.FindElement(By.ClassName("btn"));

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage LogIn(User user)
        {
            nameInput.SendKeys(user.Name);
            passwordInput.SendKeys(user.Password);
            submitBtn.Click();

            return new HomePage(driver);
        }
    }
}

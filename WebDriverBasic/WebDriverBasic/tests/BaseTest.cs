using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;

namespace WebDriverBasic.tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LogInPage logInPage;
        protected HomePage homePage;
        protected readonly User user = new User("user", "user");

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login?ReturnUrl=%2F");
            logInPage = new LogInPage(driver);
            homePage = logInPage.LogIn(user);
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

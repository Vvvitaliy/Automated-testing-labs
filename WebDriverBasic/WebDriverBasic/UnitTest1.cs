using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverBasic
{
    public class Tests
    {
        private IWebDriver driver;
        private string logInPageURL = "http://localhost:5000/Account/Login?ReturnUrl=%2F";
        private string homePageURL = "http://localhost:5000/";
        private string productsPageURL = "http://localhost:5000/Product";
        By testProductEditLocator = By.XPath("//td[.=\"testName\"]/following-sibling::td[.=\"Edit\"]/a");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(logInPageURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void LogInTest()
        {
            LogIn(driver);

            Assert.AreEqual(homePageURL, driver.Url);
        }

        [Test]
        public void AddProduct()
        {
            LogIn(driver);
            driver.FindElement(By.XPath("//div[contains(., \"All Products\")]/a")).Click();
            driver.FindElement(By.ClassName("btn")).Click();

            driver.FindElement(By.Id("ProductName")).SendKeys("testName");
            SelectElement selectCategory = new SelectElement(driver.FindElement(By.Id("CategoryId")));
            selectCategory.SelectByText("Beverages");
            SelectElement selectSupplier = new SelectElement(driver.FindElement(By.Id("SupplierId")));
            selectSupplier.SelectByText("Exotic Liquids");
            driver.FindElement(By.Id("UnitPrice")).SendKeys("1000");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("100");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("100");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("10");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("2");

            driver.FindElement(By.ClassName("btn")).Click();

            bool isProductPresent = IsElementPresent(driver, testProductEditLocator);
            Assert.IsTrue(isProductPresent);
        }

        [Test]
        public void CheckProduct()
        {
            LogIn(driver);
            driver.Navigate().GoToUrl(productsPageURL);

            bool isProductPresent = IsElementPresent(driver, testProductEditLocator);
            Assert.IsTrue(isProductPresent);

            driver.FindElement(testProductEditLocator).Click();

            SelectElement selectCategory = new SelectElement(driver.FindElement(By.Id("CategoryId")));
            SelectElement selectSupplier = new SelectElement(driver.FindElement(By.Id("SupplierId")));
            string valueAttribute = "value";

            Assert.AreEqual("testName", driver.FindElement(By.Id("ProductName")).GetAttribute(valueAttribute));
            Assert.AreEqual("Beverages", selectCategory.SelectedOption.Text);
            Assert.AreEqual("Exotic Liquids", selectSupplier.SelectedOption.Text);
            Assert.AreEqual("1000,0000", driver.FindElement(By.Id("UnitPrice")).GetAttribute(valueAttribute));
            Assert.AreEqual("100", driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute(valueAttribute));
            Assert.AreEqual("100", driver.FindElement(By.Id("UnitsInStock")).GetAttribute(valueAttribute));
            Assert.AreEqual("10", driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute(valueAttribute));
            Assert.AreEqual("2", driver.FindElement(By.Id("ReorderLevel")).GetAttribute(valueAttribute));
            Assert.IsFalse(driver.FindElement(By.Id("Discontinued")).Selected);
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

        private static void LogIn(IWebDriver driver)
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.ClassName("btn")).Click();
        }

        private static Boolean IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverBasic.PO;

namespace WebDriverBasic
{
    public class NorthwindTests
    {
        private IWebDriver driver;
        private LogInPage logInPage;
        private HomePage homePage;
        private AllProductsPage allProductsPage;
        private ProductEditingPage productEditingPage;
        private string logInPageURL = "http://localhost:5000/Account/Login?ReturnUrl=%2F";
        string testProductName = "testName";

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(logInPageURL);
            logInPage = new LogInPage(driver);
            homePage = logInPage.LogIn("user", "user");
        }

        [Test, Order(1)]
        public void LogIn()
        {
            Assert.AreEqual("Home page", homePage.GetHeadingText());
        }

        [Test]
        public void AddProduct()
        {
            allProductsPage = homePage.ClickOnAllProductsLink();
            productEditingPage = allProductsPage.ClickOnCreateNewBtn();

            productEditingPage.AddTestProduct(testProductName, "Beverages", "Exotic Liquids", "1000", "100", "100", "10", "2", false);

            Assert.IsTrue(allProductsPage.IsTestProductPresent(testProductName));
        }

        [Test]
        public void CheckProduct()
        {
            allProductsPage = new AllProductsPage(driver);
            productEditingPage = allProductsPage.ClickOnTestProductEditLink(testProductName);

            Assert.AreEqual(testProductName, productEditingPage.GetProductNameValue());
            Assert.AreEqual("Beverages", productEditingPage.GetCategoryText());
            Assert.AreEqual("Exotic Liquids", productEditingPage.GetSupplierText());
            Assert.AreEqual("1000,0000", productEditingPage.GetUnitPriceValue());
            Assert.AreEqual("100", productEditingPage.GetQuantityPerUnitValue());
            Assert.AreEqual("100", productEditingPage.GetUnitsInStockValue());
            Assert.AreEqual("10", productEditingPage.GetUnitsOnOrderValue());
            Assert.AreEqual("2", productEditingPage.GetReorderLevelValue());
            Assert.IsFalse(productEditingPage.GetDiscontinuedStatus());
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
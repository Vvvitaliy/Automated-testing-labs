using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;

namespace WebDriverBasic.step_difinitions
{
    [Binding]
    public sealed class NorthwindSteps
    {
        private IWebDriver driver;
        private LogInPage logInPage;
        private HomePage homePage;
        private AllProductsPage allProductsPage;
        ProductEditingPage productEditingPage;

        [Given(@"I open ""(.+)"" url")]
        public void GivenIOpenLoginPage(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(url);
        }

        [When(@"I login with name ""(.+)"" and password ""(.+)""")]
        public void WhenIlogin(string name, string password)
        {
            logInPage = new LogInPage(driver);
            homePage = logInPage.LogIn(new User(name, password));
        }

        [When(@"I click on All products link")]
        public void WhenIClickOnAllProductsLink()
        {
            allProductsPage = homePage.ClickOnAllProductsLink();
        }

        [When(@"I click on Create new button")]
        public void WhenIClickOnCreateNewButton()
        {
            productEditingPage = allProductsPage.ClickOnCreateNewBtn();
        }

        [When(@"I type in ProductName ""(.+)""")]
        public void WhenITypeInProductName(string productName)
        {
            productEditingPage.TypeInProductNameInput(productName);
        }

        [When(@"I select in Category ""(.+)""")]
        public void WhenISelectInCategory(string category)
        {
            productEditingPage.SelectInCategorySelect(category);
        }

        [When(@"I select in Supplier ""(.+)""")]
        public void WhenISelectInSupplier(string supplier)
        {
            productEditingPage.SelectInSupplierSelect(supplier);
        }

        [When(@"I type in UnitPrice ""(.+)""")]
        public void WhenITypeInUnitPrice(string unitPrice)
        {
            productEditingPage.TypeInUnitPriceInput(unitPrice);
        }

        [When(@"I type in QuantityPerUnit ""(.+)""")]
        public void WhenITypeInQuantityPerUnit(string quantityPerUnit)
        {
            productEditingPage.TypeInQuantityPerUnitInput(quantityPerUnit);
        }

        [When(@"I type in UnitsInStock ""(.+)""")]
        public void WhenITypeInUnitsInStock(string unitsInStock)
        {
            productEditingPage.TypeInUnitsInStockInput(unitsInStock);
        }

        [When(@"I type in UnitsOnOrder ""(.+)""")]
        public void WhenITypeInUnitsOnOrder(string unitsOnOrder)
        {
            productEditingPage.TypeInUnitsOnOrderInput(unitsOnOrder);
        }

        [When(@"I type in ReorderLevel ""(.+)""")]
        public void WhenITypeInReorderLevel(string reorderLevel)
        {
            productEditingPage.TypeInReorderLevelInput(reorderLevel);
        }

        [When(@"I click on Send button")]
        public void WhenIClickOnSendButton()
        {
            productEditingPage.ClickOnSubmitBtn();
        }

        [Then(@"there should be product with name ""(.+)""")]
        public void ThenThereShouldBeProductWithName(string productName)
        {
            Assert.IsTrue(allProductsPage.IsTestProductPresent(productName));
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

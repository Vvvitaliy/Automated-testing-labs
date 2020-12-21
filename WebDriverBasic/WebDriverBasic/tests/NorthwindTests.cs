using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;
using WebDriverBasic.service.ui;
using WebDriverBasic.tests;

namespace WebDriverBasic
{
    public class NorthwindTests : BaseTest
    {
        private AllProductsPage allProductsPage;
        private ProductEditingPage productEditingPage;
        private readonly Product product = new Product("testName", "Beverages", "Exotic Liquids", "1000", "100", "100", "10", "2", false);

        [Test, Order(1)]
        public void LogIn()
        {
            Assert.AreEqual("Home page", homePage.GetHeadingText());
        }

        [Test]
        public void AddProduct()
        {
            allProductsPage = ProductService.AddProduct(product, driver);

            Assert.IsTrue(allProductsPage.IsTestProductPresent(product));
        }

        [Test]
        public void CheckProduct()
        {
            productEditingPage = ProductService.OpenProduct(product, driver);

            Assert.IsTrue(ProductService.CompareProducts(product, productEditingPage));
        }
    }
}
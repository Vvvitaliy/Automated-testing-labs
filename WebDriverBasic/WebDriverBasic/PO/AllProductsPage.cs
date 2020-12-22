using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;

namespace WebDriverBasic.po
{
    public class AllProductsPage
    {
        private IWebDriver driver;

        private IWebElement createNewBtn => driver.FindElement(By.ClassName("btn"));
        private IWebElement testProductEditLink;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProductEditingPage ClickOnCreateNewBtn()
        {
            createNewBtn.Click();

            return new ProductEditingPage(driver);
        }

        public bool IsTestProductPresent(Product product)
        {
            try
            {
                driver.FindElement(By.XPath($"//td[.=\"{product.ProductName}\"]"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool IsTestProductPresent(string productName)
        {
            try
            {
                driver.FindElement(By.XPath($"//td[.=\"{productName}\"]"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public ProductEditingPage ClickOnTestProductEditLink(Product product)
        {
            testProductEditLink = driver.FindElement(By.XPath($"//td[.=\"{product.ProductName}\"]/following-sibling::td[.=\"Edit\"]/a"));
            testProductEditLink.Click();

            return new ProductEditingPage(driver);
        }
    }
}

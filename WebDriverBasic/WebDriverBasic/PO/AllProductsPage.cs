using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.PO
{
    class AllProductsPage
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

        public bool IsTestProductPresent(string testProductName)
        {
            try
            {
                driver.FindElement(By.XPath($"//td[.=\"{testProductName}\"]"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public ProductEditingPage ClickOnTestProductEditLink(string testProductName)
        {
            testProductEditLink = driver.FindElement(By.XPath($"//td[.=\"{testProductName}\"]/following-sibling::td[.=\"Edit\"]/a"));
            testProductEditLink.Click();

            return new ProductEditingPage(driver);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.PO
{
    class HomePage
    {
        private IWebDriver driver;
        private IWebElement heading => driver.FindElement(By.CssSelector("h2"));
        private IWebElement allProductsLink => driver.FindElement(By.XPath("//div[contains(., \"All Products\")]/a"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AllProductsPage ClickOnAllProductsLink()
        {
            allProductsLink.Click();

            return new AllProductsPage(driver);
        }

        public string GetHeadingText()
        {
            return heading.Text;
        }
    }
}

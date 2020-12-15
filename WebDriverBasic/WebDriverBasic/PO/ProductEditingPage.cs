using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.PO
{
    class ProductEditingPage
    {
        private IWebDriver driver;

        private IWebElement productNameInput => driver.FindElement(By.Id("ProductName"));
        private SelectElement categorySelect => new SelectElement(driver.FindElement(By.Id("CategoryId")));
        private SelectElement supplierSelect => new SelectElement(driver.FindElement(By.Id("SupplierId")));
        private IWebElement unitPriceInput => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement quantityPerUnitInput => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement unitsInStockInput => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement unitsOnOrderInput => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement reorderLevelInput => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement discontinuedCheckbox => driver.FindElement(By.Id("Discontinued"));
        private IWebElement submitBtn => driver.FindElement(By.ClassName("btn"));

        public ProductEditingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetProductNameValue()
        {
            return productNameInput.GetAttribute("value");
        }

        public string GetCategoryText()
        {
            return categorySelect.SelectedOption.Text;
        }

        public string GetSupplierText()
        {
            return supplierSelect.SelectedOption.Text;
        }

        public string GetUnitPriceValue()
        {
            return unitPriceInput.GetAttribute("value");
        }

        public string GetQuantityPerUnitValue()
        {
            return quantityPerUnitInput.GetAttribute("value");
        }

        public string GetUnitsInStockValue()
        {
            return unitsInStockInput.GetAttribute("value");
        }

        public string GetUnitsOnOrderValue()
        {
            return unitsOnOrderInput.GetAttribute("value");
        }

        public string GetReorderLevelValue()
        {
            return reorderLevelInput.GetAttribute("value");
        }

        public bool GetDiscontinuedStatus()
        {
            return discontinuedCheckbox.Selected;
        }

        public AllProductsPage AddTestProduct(string productName, string category, string supplier, string unitPrice, 
            string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel, bool discontinued)
        {
            //productNameInput.SendKeys(productName);
            new Actions(driver).SendKeys(productNameInput, productName).Build().Perform();

            categorySelect.SelectByText(category);
            supplierSelect.SelectByText(supplier);

            //unitPriceInput.SendKeys(unitPrice);
            new Actions(driver).SendKeys(unitPriceInput, unitPrice).Build().Perform();

            quantityPerUnitInput.SendKeys(quantityPerUnit);
            unitsInStockInput.SendKeys(unitsInStock);
            unitsOnOrderInput.SendKeys(unitsOnOrder);
            reorderLevelInput.SendKeys(reorderLevel);

            if (discontinued)
            {
                discontinuedCheckbox.Click();
            }

            //submitBtn.Click();
            new Actions(driver).Click(submitBtn).Build().Perform();

            return new AllProductsPage(driver);
        }
    }
}

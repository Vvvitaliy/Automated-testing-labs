using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;

namespace WebDriverBasic.service.ui
{
    class ProductService
    {
        public static AllProductsPage AddProduct(Product product, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            AllProductsPage allProductsPage = homePage.ClickOnAllProductsLink();
            ProductEditingPage productEditingPage = allProductsPage.ClickOnCreateNewBtn();
            productEditingPage.AddTestProduct(product);

            return allProductsPage;
        }

        public static ProductEditingPage OpenProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            return allProductsPage.ClickOnTestProductEditLink(product);
        }

        public static bool CompareProducts(Product expectedProduct, ProductEditingPage actualProduct)
        {
            return expectedProduct.ProductName.Equals(actualProduct.GetProductNameValue()) &&
                expectedProduct.Category.Equals(actualProduct.GetCategoryText()) &&
                expectedProduct.Supplier.Equals(actualProduct.GetSupplierText()) &&
                Double.Parse(expectedProduct.UnitPrice).Equals(Double.Parse(actualProduct.GetUnitPriceValue())) &&
                expectedProduct.QuantityPerUnit.Equals(actualProduct.GetQuantityPerUnitValue()) &&
                expectedProduct.UnitsInStock.Equals(actualProduct.GetUnitsInStockValue()) &&
                expectedProduct.UnitsOnOrder.Equals(actualProduct.GetUnitsOnOrderValue()) &&
                expectedProduct.ReorderLevel.Equals(actualProduct.GetReorderLevelValue()) &&
                expectedProduct.Discontinued.Equals(actualProduct.GetDiscontinuedStatus());
        }
    }
}

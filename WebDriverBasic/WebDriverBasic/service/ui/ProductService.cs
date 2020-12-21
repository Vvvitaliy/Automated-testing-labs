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
            Product temp = new Product(actualProduct.GetProductNameValue(), actualProduct.GetCategoryText(),
                actualProduct.GetSupplierText(), actualProduct.GetUnitPriceValue(), 
                actualProduct.GetQuantityPerUnitValue(), actualProduct.GetUnitsInStockValue(), 
                actualProduct.GetUnitsOnOrderValue(), actualProduct.GetReorderLevelValue(),
                actualProduct.GetDiscontinuedStatus());

            return expectedProduct.Equals(temp);
        }
    }
}

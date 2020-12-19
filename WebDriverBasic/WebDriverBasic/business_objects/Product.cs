using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.business_objects
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Product(string productName, string category, string supplier, string unitPrice, string quantityPerUnit, 
            string unitsInStock, string unitsOnOrder, string reorderLevel, bool discontinued)
        {
            ProductName = productName;
            Category = category;
            Supplier = supplier;
            UnitPrice = unitPrice;
            QuantityPerUnit = quantityPerUnit;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
    }
}

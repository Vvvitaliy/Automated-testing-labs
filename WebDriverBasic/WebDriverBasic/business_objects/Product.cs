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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product product = (Product)obj;

            return this.ProductName.Equals(product.ProductName) &&
                this.Category.Equals(product.Category) &&
                this.Supplier.Equals(product.Supplier) &&
                Double.Parse(this.UnitPrice).Equals(Double.Parse(product.UnitPrice)) &&
                this.QuantityPerUnit.Equals(product.QuantityPerUnit) &&
                this.UnitsInStock.Equals(product.UnitsInStock) &&
                this.UnitsOnOrder.Equals(product.UnitsOnOrder) &&
                this.ReorderLevel.Equals(product.ReorderLevel) &&
                this.Discontinued.Equals(product.Discontinued);
        }
    }
}

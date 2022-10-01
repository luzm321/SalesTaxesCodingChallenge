using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCodingChallenge
{
    public class Product
    {
        public string Name;
        public string Type;
        public string Price;
        public bool Import;

        public Product(string name, string type, string price, bool import)
        {
            Name = name;
            Type = type;
            Price = price;
            Import = import;
        }

        public string GetProductName()
        {
            return Name;
        }

        public string GetProductType()
        {
            return Type;
        }

        public string GetProductPrice()
        {
            return Price;
        }

        public bool GetProductImportStatus()
        {
            return Import;
        }
    }
}
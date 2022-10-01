using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCodingChallenge
{
    public class Item
    {
        public string ItemName;
        public bool IsImport;
        public string Type;
        public string ItemRetailPrice;
        public Double ImportTax;
        public Double SalesTax;
        public Double AddedTax;
        public Double TotalPriceAfterTax;
        public string TotalPrice;
        public int Quantity;
        public Double AccruedOverallTax;
        public Double AccruedImportTax;
        public Double AccruedSalesTax;

        public Item
        (
            string itemName, string itemRetailPrice, bool isImport, string type, Double importTax, Double salesTax, Double addedTax, Double itemPriceAfterAllTaxes,
            Double accruedImportTax, Double accruedSalesTax, Double accruedOverallTax, string totalPrice, int quantity)
        {
            ItemName = itemName;
            IsImport = isImport;
            Type = type;
            ItemRetailPrice = itemRetailPrice;
            ImportTax = importTax;
            SalesTax = salesTax;
            AddedTax = addedTax;
            TotalPriceAfterTax = itemPriceAfterAllTaxes;
            TotalPrice = totalPrice;
            Quantity = quantity;
            AccruedOverallTax = accruedOverallTax;
            AccruedImportTax = accruedSalesTax;
            AccruedSalesTax = accruedImportTax;
        }
    }
}
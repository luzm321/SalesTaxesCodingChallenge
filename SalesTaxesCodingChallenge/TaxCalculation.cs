using SalesTaxesCodingChallenge;
using System;
using System.Collections.Generic;

namespace SalesTaxesCodingChallenge
{
    public class TaxCalculation
    {
        public string Price;
        public bool IsImport;
        public string Type;

        public TaxCalculation(Product product)
        {
            Price = product.Price;
            IsImport = product.Import;
            Type = product.Type;
        }


        public double CalculateImportTax()
        {

            Double totalPriceAfterImportTax = 0;
            Double importTax = 0;
            Double itemTax = .05;
            Double productPrice;

            productPrice = CurrencyToNumberConverter.ConvertFromCurrency(Price);

            if (IsImport)
            {
                // Round up then add to original price to get the total with tax.
                Double calculatedPriceAfter5PercentTax = (productPrice * itemTax) + productPrice;
                // Reference: https://stackoverflow.com/questions/10413573/rounding-up-to-the-nearest-0-05-in-javascript
                Double roundedToNearest5Cent = (Math.Ceiling(calculatedPriceAfter5PercentTax * 20) / 20);
                totalPriceAfterImportTax += roundedToNearest5Cent;
                importTax = totalPriceAfterImportTax - productPrice;
            }

            return importTax;
        }

        public Double CalculateSalesTax()
        {
            //* This calculates the total amount you paid after taxes.
            Double totalPriceAfterSalesTax = 0;
            Double salesTax = 0;
            Double itemTax = .10;
            Double productPrice;

            if (Type != "Food" && Type != "Medical" && Type != "Book")
            {
                productPrice = CurrencyToNumberConverter.ConvertFromCurrency(Price);
                Double calculatedPriceAfter10PercentTax = (productPrice * itemTax) + productPrice;
                //? This rounds up to the nearest 5 cents.
                Double roundedToNearest5Cent = (Math.Ceiling(calculatedPriceAfter10PercentTax * 20) / 20);
                totalPriceAfterSalesTax += roundedToNearest5Cent;
                salesTax = totalPriceAfterSalesTax - productPrice;
            }

            return salesTax;
        }

        public Tuple<Double, Double, Double, Double> CalculateTaxesOfItem()
        {

            // Reference: https://www.tutorialsteacher.com/csharp/csharp-tuple

            Double productPrice = CurrencyToNumberConverter.ConvertFromCurrency(Price);
            Double importTax = CalculateImportTax();
            Double salesTax = CalculateSalesTax();
            Double itemPriceAfterAllTaxes = (importTax + salesTax) + productPrice;
            Double addedTax = importTax + salesTax;
            Console.WriteLine($"Import Tax: {importTax} Sales Tax: {salesTax} Added Tax: {addedTax}");

            return Tuple.Create(importTax, salesTax, addedTax, itemPriceAfterAllTaxes);
        }

    }

}
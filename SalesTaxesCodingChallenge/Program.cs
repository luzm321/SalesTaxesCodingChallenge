using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SalesTaxesCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Hello, welcome to The Store!");
            Console.WriteLine();

            Console.WriteLine("Choose item to purchase by number:");
            Console.WriteLine();

            List<Product> products = new List<Product>();
            products.Add(new Product("Ramen Noodles", "Food", "5$", false));
            products.Add(new Product("Television", "Electronics", "400$", false));
            products.Add(new Product("Mexican Chips", "Food", "15$", true));
            products.Add(new Product("The Pragmatic Programmer", "Book", "25$", true));
            products.Add(new Product("Stethoscope", "Medical", "100$", false));
            products.Add(new Product("Playstation 5", "Merchandise", "1,000$", true));

            bool shoppingInProgress = true;
            string response = "";

            while (shoppingInProgress)
            {
                DisplayProducts(products);
                Console.WriteLine();
                Console.Write("Select item to purchase: ");
                response = Console.ReadLine().ToLower();
                bool responseIsNumber = int.TryParse(response, out _);
                // Error Handling: Check if user input is a number
                if (responseIsNumber)
                {
                    int numberSelection = int.Parse(response);
                    // Check that number is within range and above 0
                    if (numberSelection <= products.Count && numberSelection > 0)
                    {
                        Product productSelected = products[Int32.Parse(response) - 1];
                        Tuple<Double, Double, Double, Double> taxCalculations = new TaxCalculation(productSelected).CalculateTaxesOfItem();
                        Double importTax = taxCalculations.Item1;
                        Double salesTax = taxCalculations.Item2;
                        Double addedTax = taxCalculations.Item3;
                        Double itemPriceAfterAllTaxes = taxCalculations.Item4;
                        Item selectedItem = new Item
                        (
                            productSelected.Name, productSelected.Price, productSelected.Import, productSelected.Type, importTax, salesTax, addedTax,
                            itemPriceAfterAllTaxes, importTax, salesTax, addedTax, productSelected.Price, 1
                        );
                        ShoppingCart.AddItemToShoppingCart(selectedItem);
                        Console.WriteLine($"{productSelected.Name} was added to cart! Quantity in Cart: {ShoppingCart.GetItemsFromShoppingCart().Count}");
                        Console.WriteLine();
                        Console.Write("Ready to checkout? (Y/N): ");
                        response = Console.ReadLine().ToLower();
                        if (response == "y")
                        {
                            shoppingInProgress = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The number you selected is not valid and must be from 1 - 6");
                    }
                }
                else
                {
                    Console.WriteLine("Please type in a valid number from the product selection displayed.");
                }
            }

            List<Item> cart = ShoppingCart.GetItemsFromShoppingCart();
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Number of Items in Cart: {cart.Count}");
            DisplayReceipt(cart);

        }

        public static void DisplayProducts(List<Product> products)
        {
            int i = 1;
            foreach (var item in products)
            {
                Console.WriteLine($"{i}) Name: {item.Name} || Price: {item.Price}$");
                i++;
            }
        }

        public static void DisplayReceipt(List<Item> shoppingCart)
        {
            Console.WriteLine($"Receipt: {shoppingCart.Count}");
            Double totalTaxes = CalculateTaxesForAllPurchasedItems(shoppingCart);
            Double total = CalculateTotalPrice(shoppingCart);
            int i = 1;
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"{i}) Name: {item.ItemName} {(shoppingCart.Count > 1 ? $"|| Price: {item.TotalPriceAfterTax}$" : "")} {(item.Quantity > 1 ? $"|| ({item.Quantity}) @ {item.ItemRetailPrice}" : "")}");
                i++;
            }
            Console.WriteLine($"Total Taxes: {totalTaxes}$");
            Console.WriteLine($"Total: {total}$");
        }

        public static Double CalculateTotalPrice(List<Item> shoppingCart)
        {
            Double total = 0;
            foreach (var item in shoppingCart)
            {
                total += item.TotalPriceAfterTax;
            }
            return total;
        }

        public static Double CalculateTaxesForAllPurchasedItems(List<Item> shoppingCart)
        {
            Double totalTaxes = 0;
            foreach (var item in shoppingCart)
            {
                totalTaxes += item.AccruedOverallTax;
            }
            return totalTaxes;
        }
    }
}
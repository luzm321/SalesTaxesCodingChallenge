using SalesTaxesCodingChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxesCodingChallenge
{
    public class ShoppingCart
    {
        static List<Item> shoppingCartItems = new List<Item>();

        public static List<Item> AddItemToShoppingCart(Item item)
        {
            bool containsItem = shoppingCartItems.Any(cartItem => cartItem.ItemName == item.ItemName);
            if (containsItem)
            {
                UpdateItemFromShoppingCart(item);
                return shoppingCartItems;
            }
            else
            {
                shoppingCartItems.Add(item);
                return shoppingCartItems;
            }
        }

        public static List<Item> UpdateItemFromShoppingCart(Item item)
        {
            int index = 0;
            foreach (var cartItem in shoppingCartItems)
            {
                if (cartItem.ItemName == item.ItemName)
                {
                    index = shoppingCartItems.IndexOf(cartItem);
                }
            }
            shoppingCartItems.RemoveAt(index);

            int newItemQuantity = item.Quantity + 1;
            Double newTotalPrice = CurrencyToNumberConverter.ConvertFromCurrency(item.TotalPrice) + CurrencyToNumberConverter.ConvertFromCurrency(item.ItemRetailPrice);
            string newTotalPriceString = newTotalPrice.ToString();
            Double newPriceAfterTax = (item.TotalPriceAfterTax + item.TotalPriceAfterTax);
            Double accruedImportTax = (item.AccruedImportTax + item.ImportTax);
            Double accruedSalesTax = (item.AccruedSalesTax + item.SalesTax);
            Double accruedOverallTax = (item.AccruedOverallTax + item.AddedTax);
            Item updatedItem = new Item
            (
                item.ItemName, item.ItemRetailPrice, item.IsImport, item.Type, item.ImportTax, item.SalesTax, item.AddedTax, newPriceAfterTax,
                accruedImportTax, accruedSalesTax, accruedOverallTax, newTotalPriceString, newItemQuantity
            );
            shoppingCartItems.Add(updatedItem);
            return shoppingCartItems;
        }

        public static List<Item> GetItemsFromShoppingCart()
        {
            return shoppingCartItems;
        }

        public static List<Item> EmptyShoppingCart()
        {
            shoppingCartItems = new List<Item>();
            return shoppingCartItems;
        }
    }
}
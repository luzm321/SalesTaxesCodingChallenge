using Xunit;
using SalesTaxesCodingChallenge;


namespace SalesTaxesTest
{
    public class UnitTest1
    {
        [Fact]
        public void ProductIsCreatedProperly()
        {
            var tvProduct = new Product("Television", "Electronics", "400$", false);
            Assert.IsType<Product>(tvProduct);
        }

        [Fact]
        public void ItemIsCreatedProperly()
        {
            var tvItem = new Item("Television", "400$", false, "Electronics", 0, 40, 40, 440, 0, 40, 40, "440", 1);
            Assert.IsType<Item>(tvItem);
        }

        [Fact]
        public void ConvertingFromCurrencyIsSuccessful()
        {
            var tvProduct = new Product("Television", "Electronics", "400$", false);
            var productPrice = CurrencyToNumberConverter.ConvertFromCurrency(tvProduct.Price);
            Assert.IsType<Double>(productPrice);
        }

        [Fact]
        public void AddingItemToCartIsSuccessful()
        {
            var tvItem = new Item("Ramen Noodles", "5$", false, "Food", 0, .5, .5, 5.50, 0, .5, .5, "5.50", 1);
            List<Item> shoppingCart = ShoppingCart.AddItemToShoppingCart(tvItem);
            Assert.NotEmpty(shoppingCart);
            ShoppingCart.EmptyShoppingCart();
        }

        [Fact(Skip = "Needs rework")]
        public void UpdatingItemToCartIsSuccessful()
        {
            var tvItem = new Item("Television", "400$", false, "Electronics", 0, 40, 40, 440, 0, 40, 40, "440", 1);
            List<Item> shoppingCart = ShoppingCart.AddItemToShoppingCart(tvItem);
            var updatedTvItem = new Item("Television", "400$", false, "Electronics", 0, 80, 80, 880, 0, 80, 80, "480", 1);
            Console.WriteLine(tvItem.TotalPriceAfterTax);
            Console.WriteLine(updatedTvItem.TotalPriceAfterTax);
            List<Item> updatedShoppingCart = ShoppingCart.UpdateItemFromShoppingCart(updatedTvItem);
            //List<Item> updatedShoppingCart = ShoppingCart.GetItemsFromShoppingCart();
            Assert.NotEqual(updatedShoppingCart, shoppingCart);
        }
    }
}
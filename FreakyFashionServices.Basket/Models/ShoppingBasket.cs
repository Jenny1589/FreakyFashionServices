using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models
{
    public class ShoppingBasket
    {
        public IEnumerable<BasketItem> Items { get; set; }

        public class BasketItem
        {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public double UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}

using System.Collections.Generic;

namespace FreakyFashionServices.Order.Models
{
    public class Basket
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

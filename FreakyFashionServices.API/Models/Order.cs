using System.Collections.Generic;

namespace FreakyFashionServices.API.Models
{
    public class Order
    {
        public string CustomerIdentifier { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public class OrderItem {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public double UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}

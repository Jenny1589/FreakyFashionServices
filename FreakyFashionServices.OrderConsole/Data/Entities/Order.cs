using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreakyFashionServices.OrderConsole.Data.Entities
{
    public class Order
    {
        [JsonConstructor]
        public Order(string customerIdentifier, IEnumerable<OrderItem> items)
            : this(customerIdentifier)
        {
            Items = items;
        }

        public Order(string customerIdentifier)
        {
            CustomerIdentifier = customerIdentifier;
        }

        public int OrderId { get; protected set; }
        public string CustomerIdentifier { get; protected set; }
        public IEnumerable<OrderItem> Items { get; protected set; }

        public class OrderItem
        {
            public OrderItem(string id, string productName, double unitPrice, int quantity, int orderId)
            {
                Id = id;
                ProductName = productName;
                UnitPrice = unitPrice;
                Quantity = quantity;
                OrderId = orderId;
            }

            public string Id { get; protected set; }
            public int OrderId { get; protected set; }
            public string ProductName { get; protected set; }
            public double UnitPrice { get; protected set; }
            public int Quantity { get; protected set; }
        }        
    }
}

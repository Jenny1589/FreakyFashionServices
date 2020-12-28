using System;

namespace FreakyFashionServices.Catalog.Data.Entities
{
    public class Product
    {
        public Product(Guid id, string name, string description, double price, int availableStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double Price { get; protected set; }
        public int AvailableStock { get; protected set; }
    }
}

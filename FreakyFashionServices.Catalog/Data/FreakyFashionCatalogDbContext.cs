using FreakyFashionServices.Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FreakyFashionServices.Catalog.Data
{
    public class FreakyFashionCatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public FreakyFashionCatalogDbContext(DbContextOptions<FreakyFashionCatalogDbContext> options)
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .Property(p => p.Id)
                .ValueGeneratedNever();

            SeedProducts(modelBuilder);
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product(
                        id: new Guid("055efd65-67e4-4042-96d9-25714f470a0d"),
                        name: "Freaky Shirt",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " + 
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " + 
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " + 
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " + 
                            "aliquet nec, vulputate eget, arcu.",
                        price: 129.99,
                        availableStock: 99
                    ),
                    new Product(
                        id: new Guid("7bbcbd1a-5fdc-43d3-8f14-f3729c7a82b5"),
                        name: "Awsome shooes",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 559.99,
                        availableStock: 12
                    ),
                    new Product(
                        id: new Guid("7b686050-44e6-4f63-82e9-a719891a5d95"),
                        name: "Holy jeans",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 899.99,
                        availableStock: 54
                    ),
                    new Product(
                        id: new Guid("baaf66b6-5ffb-41b4-af3a-20340d7a21cf"),
                        name: "Soft hoody",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 439.99,
                        availableStock: 5
                    ),
                    new Product(
                        id: new Guid("621c95fb-a361-4454-a2c5-013947273be8"),
                        name: "Flowery dress",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 299.99,
                        availableStock: 120
                    ),
                    new Product(
                        id: new Guid("e37f8c14-1ff7-4adf-8419-d0560505b86f"),
                        name: "Crazy socks",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 9.99,
                        availableStock: 1386
                    ),
                    new Product(
                        id: new Guid("466e2aa4-6c1e-4eba-8202-aa5ed6dd0455"),
                        name: "Soft onesie",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 999.99,
                        availableStock: 25
                    ),
                    new Product(
                        id: new Guid("d713b03c-e2ac-4431-a29a-1e06fe46e30a"),
                        name: "Cool jacket",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 1959.99,
                        availableStock: 5
                    ),
                    new Product(
                        id: new Guid("1d06a7fb-a3af-4877-8a90-294a3203aee1"),
                        name: "Sneaky sneakers",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 499.99,
                        availableStock: 132
                    ),
                    new Product(
                        id: new Guid("6d759a44-ddb8-4a86-b94e-b86c2a70786b"),
                        name: "Party dress",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 859.99,
                        availableStock: 42
                    ),
                    new Product(
                        id: new Guid("1d8ef6b7-ba44-4a93-839e-f5996e8950b1"),
                        name: "Wonderful trousers",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 329.99,
                        availableStock: 37
                    ),
                    new Product(
                        id: new Guid("3fb03648-0141-4bf3-bf92-6783433cfd3b"),
                        name: "Wonder underware",
                        description: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " +
                            "Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque " +
                            "penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                            "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. " +
                            "Nulla consequat massa quis enim. Donec pede justo, fringilla vel, " +
                            "aliquet nec, vulputate eget, arcu.",
                        price: 1.99,
                        availableStock: 13865
                    )
                );
        }
    }
}

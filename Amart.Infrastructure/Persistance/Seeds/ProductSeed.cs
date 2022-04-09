using Amart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Amart.Infrastructure.Persistance.Seeds
{
    public static class ProductSeed
    {
        internal static ModelBuilder AddProductSeedData(this ModelBuilder builder)
        {
            var products = new Product[]
            {
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 250,
                   Name = "IPhone 13S"
                },
                new Product
                {
                  Id = Guid.NewGuid(),
                  Created = DateTime.Now,
                  Price = 1250,
                  Name = "Acer Aspire"
                },
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 1600,
                   Name = "Samsung S20"
                },
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 250,
                   Name = "Coca cola"
                },
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 20,
                   Name = "Ball"
                },
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 630,
                   Name = "Monitor"
                },
                new Product
                {
                   Id = Guid.NewGuid(),
                   Created = DateTime.Now,
                   Price = 450,
                   Name = "Book"
                }
            };

            builder.Entity<Product>().HasData(products);

            return builder;
        }
    }
}
using System;

namespace Amart.Application.MediatR.Products.Queries.GetProducts
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }
    }
}
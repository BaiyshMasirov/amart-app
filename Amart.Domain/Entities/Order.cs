using Amart.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Amart.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public IList<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}
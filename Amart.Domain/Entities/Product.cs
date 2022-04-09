using System;

namespace Amart.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
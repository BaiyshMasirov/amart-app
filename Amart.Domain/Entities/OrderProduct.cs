using System;

namespace Amart.Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
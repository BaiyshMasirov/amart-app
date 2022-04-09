using Amart.Domain.Enums;
using System;

namespace Amart.Application.MediatR.Orders.Queries.GetOrders
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime Created { get; set; }
    }
}
using Amart.Application.MediatR.Orders.Queries.GetOrders;
using Amart.Domain.Entities;

namespace Amart.Application.Common.Extensions
{
    public static class MappintExtensions
    {
        public static OrderDto AsDto(this Order entity)
        {
            return new OrderDto
            {
                Id = entity.Id,
                Name = entity.Name,
                TotalAmount = entity.TotalAmount,
                Status = entity.Status,
                Created = entity.Created
            };
        }
    }
}
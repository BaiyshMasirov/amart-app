using Amart.Application.Common.Interfaces;
using Amart.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Products.Queries.GetProducts
{
    public record GetProductsByOrderIdQuery(Guid UserId, Guid OrderId, int Page = 1) : IRequest<List<Product>>;

    public class GetProductsByOrderIdQueryHandler : IRequestHandler<GetProductsByOrderIdQuery, List<Product>>
    {
        private readonly IAmartEFContext _context;

        public GetProductsByOrderIdQueryHandler(IAmartEFContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var rows = await _context.Orders.Where(x => x.Id == request.OrderId).SelectMany(p => p.Products).ToListAsync();

            return rows;
        }
    }
}
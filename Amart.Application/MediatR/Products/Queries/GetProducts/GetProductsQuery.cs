using Amart.Application.Common.Interfaces;
using Amart.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Products.Queries.GetProducts
{
    public record GetProductsQuery() : IRequest<List<Product>>;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IAmartEFContext _context;

        public GetProductsQueryHandler(IAmartEFContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var rows = await _context.Products.Where(x => x.Price != 0).ToListAsync();

            return rows;
        }
    }
}
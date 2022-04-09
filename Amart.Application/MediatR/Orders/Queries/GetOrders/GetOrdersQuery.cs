using Amart.Application.Common;
using Amart.Application.Common.Extensions;
using Amart.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(Guid UserId, int Page = 1) : IRequest<IPager<OrderDto>>;

    public class GetComplaintsQueryHandler : IRequestHandler<GetOrdersQuery, IPager<OrderDto>>
    {
        private readonly IAmartEFContext _context;

        public GetComplaintsQueryHandler(IAmartEFContext context)
        {
            _context = context;
        }

        public async Task<IPager<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var rows = _context.OrderProducts.Include(x => x.Order)
                .Where(x => x.UserId == request.UserId).AsNoTracking();

            return await rows
                .Select(x => x.Order.AsDto())
                .ToPagerListAsync(request.Page, Pagination.PAGE_SIZE);
        }
    }
}
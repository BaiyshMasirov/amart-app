using Amart.Application.Common.Interfaces;
using Amart.Application.Models;
using Amart.Domain.Entities;
using Amart.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public IList<Guid> ProductsId { get; set; }

        public CreateOrderCommand()
        {
            ProductsId = new List<Guid>();
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IAmartEFContext _context;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IAmartEFContext context,
                                         ILogger<CreateOrderCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var currentUserOrders = _context.OrderProducts.Where(x => x.UserId == command.UserId
                                                                    && x.Created.DayOfYear == DateTime.Now.DayOfYear);

                if (currentUserOrders.Count() != 0)
                    return Result.Failure("You already have 10 order, try tomorrow");

                var order = new Order
                {
                    Name = command.Name,
                    TotalAmount = command.TotalAmount,
                    Status = command.Status,
                    Created = DateTime.Now,
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync(cancellationToken);

                foreach (var product in command.ProductsId)
                {
                    var orderProduct = new OrderProduct
                    {
                        ProductId = product,
                        OrderId = order.Id,
                        Created = DateTime.Now,
                        UserId = command.UserId
                    };
                    _context.OrderProducts.Add(orderProduct);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Result.Success("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create order with: {ex.Message}");
                return Result.Failure("Error");
            }
        }
    }
}
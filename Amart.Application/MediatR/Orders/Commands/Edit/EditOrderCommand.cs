using Amart.Application.Common.Interfaces;
using Amart.Application.Models;
using Amart.Domain.Entities;
using Amart.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Orders.Commands
{
    public class EditOrderCommand : IRequest<Result>
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public IList<Guid> ProductsId { get; set; }

        public EditOrderCommand()
        {
            ProductsId = new List<Guid>();
        }
    }

    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, Result>
    {
        private readonly IAmartEFContext _context;
        private readonly ILogger<EditOrderCommandHandler> _logger;

        public EditOrderCommandHandler(IAmartEFContext context,
                                         ILogger<EditOrderCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Handle(EditOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _context.Orders.Where(x => x.Id == command.OrderId).FirstOrDefaultAsync(cancellationToken);

                order.Updated = DateTime.Now;
                order.Name = command.Name;
                order.TotalAmount = command.TotalAmount;

                if (order.Status == OrderStatus.Submited)
                    return Result.Failure("Order already submitted");

                var prevOrderProducts = _context.OrderProducts.Where(x => x.OrderId == command.OrderId).ToList();

                _context.OrderProducts.RemoveRange(prevOrderProducts);
                await _context.SaveChangesAsync(cancellationToken);

                foreach (var product in command.ProductsId)
                {
                    var orderProduct = new OrderProduct
                    {
                        ProductId = product,
                        OrderId = command.OrderId,
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
                _logger.LogError($"Edit error order with: {ex.Message}");
                return Result.Failure($"Error on create {ex.ToString()}");
            }
        }
    }
}
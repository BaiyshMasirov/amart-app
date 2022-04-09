using FluentValidation;

namespace Amart.Application.MediatR.Orders.Commands.Create
{
    public class CreateOrderCommandvalidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandvalidation()
        {
            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("Products cannot be empty");
            RuleFor(x => x.TotalAmount)
                .LessThanOrEqualTo(10000).WithMessage("Total amount must be less than 10000");
        }
    }
}
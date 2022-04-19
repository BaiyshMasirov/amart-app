using FluentValidation;

namespace Amart.Application.MediatR.Orders.Commands.Edit
{
    public class EditOrderCommandValidation : AbstractValidator<EditOrderCommand>
    {
        public EditOrderCommandValidation()
        {
            RuleFor(x => x.ProductsId)
                .NotEmpty().WithMessage("Products cannot be empty");
            RuleFor(x => x.TotalAmount)
                .LessThanOrEqualTo(10000).WithMessage("Total amount must be less than 10000");
        }
    }
}
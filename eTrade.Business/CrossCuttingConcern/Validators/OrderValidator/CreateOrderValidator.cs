using eTrade.Core.CrossCuttingConcern.ViewModels.OrderVMs;
using FluentValidation;

namespace eTrade.Business.CrossCuttingConcern.Validators.OrderValidator
{
    public class CreateOrderValidator:AbstractValidator<OrderCreateVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(p => p.Description)
                   .NotEmpty().NotNull().WithMessage("Description can not be empty.").MinimumLength(20).WithMessage("Product description should be between 3 and 200 characters");

            RuleFor(s => s.Address)
                .NotNull().NotEmpty().WithMessage("Order Address can not be empty");

            RuleFor(p => p.OrderDate)
                .NotNull().NotEmpty().WithMessage("Order Date can not be empty");
        }
    }
}

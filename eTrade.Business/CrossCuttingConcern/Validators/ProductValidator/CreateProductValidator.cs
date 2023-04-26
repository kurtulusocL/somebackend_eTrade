using eTrade.Core.CrossCuttingConcern.ViewModels.ProductVMs;
using FluentValidation;

namespace eTrade.Business.CrossCuttingConcern.Validators.ProductValidator
{
    public class CreateProductValidator : AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                   .NotEmpty().NotNull().WithMessage("Product name can not be empty.").MaximumLength(200).MinimumLength(3).WithMessage("Product name should be between 3 and 200 characters");

            RuleFor(s => s.Stock)
                .NotNull().NotEmpty().WithMessage("Stock can not be empty").Must(s => s >= 0).WithMessage("Stock can not be negative");

            RuleFor(p=>p.Price)
                .NotNull().NotEmpty().WithMessage("Price can not be empty").Must(s => s >= 0).WithMessage("Price can not be negative");
        }
    }
}

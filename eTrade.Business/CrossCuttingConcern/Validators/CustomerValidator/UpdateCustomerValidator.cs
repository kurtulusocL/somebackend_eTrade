using eTrade.Core.CrossCuttingConcern.ViewModels.CustomerVMs;
using FluentValidation;

namespace eTrade.Business.CrossCuttingConcern.Validators.CustomerValidator
{
    public class UpdateCustomerValidator : AbstractValidator<CustomerUpdateVM>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(p => p.NameSurname)
                 .NotEmpty().NotNull().WithMessage("Name Surname can not be empty.").MaximumLength(20).MinimumLength(3).WithMessage("Name Surname should be between 3 and 20 characters");
        }
    }
}

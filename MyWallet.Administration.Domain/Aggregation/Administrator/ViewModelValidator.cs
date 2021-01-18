using FluentValidation;
using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    public sealed class ViewModelValidator : Validator<AdministratorViewModel>
    {
        public override void ConfigureValidationOptions()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(40);
            RuleFor(x => x.Surname).NotNull().NotEmpty().MaximumLength(40);
            When(x => !string.IsNullOrEmpty(x.Password), () => RuleFor(x => x.Password).MaximumLength(10).MinimumLength(4));
        }
    }
}

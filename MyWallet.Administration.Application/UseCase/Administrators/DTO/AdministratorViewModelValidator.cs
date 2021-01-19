using FluentValidation;

namespace MyWallet.Administration.Application.UseCase.Administrators.DTO
{
    public sealed class AdministratorViewModelValidator : AbstractValidator<AdministratorViewModel>
    {
        public AdministratorViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(40);
            RuleFor(x => x.Surname).NotNull().NotEmpty().MaximumLength(40);
            When(x => !string.IsNullOrEmpty(x.Password), () => RuleFor(x => x.Password).MaximumLength(10).MinimumLength(4));
        }
    }
}

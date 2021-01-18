using FluentValidation;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public abstract class Validator<TViewModel> : AbstractValidator<TViewModel> where TViewModel : ViewModel
    {
        public Validator() => ConfigureValidationOptions();
        
        /// <summary>
        /// Configure
        /// </summary>
        public abstract void ConfigureValidationOptions();
    }
}

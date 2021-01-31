using System;

namespace MyWallet.Administration.Application.UseCase.Administrators.DTO
{
    using MyWallet.Administration.Application.UseCase;
    using MyWallet.Administration.Domain.Aggregation.Administrator;

    public class AdministratorViewModel : EntityViewModelPersistent<Guid, Administrator>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public DateTime? CreationAt { get; set; }
        public string Password { get; set; }
        public uint ConcurrencyToken { get; set; }

        public static implicit operator Administrator(AdministratorViewModel viewModel)
        {
            return viewModel.Map<Administrator>();
        }
    }
}

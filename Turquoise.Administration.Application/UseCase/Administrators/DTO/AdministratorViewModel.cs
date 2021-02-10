using System;

namespace Turquoise.Administration.Application.UseCase.Administrators.DTO
{
    using Turquoise.Administration.Application.UseCase;
    using Turquoise.Administration.Domain.Aggregation.Administrator;

    public class AdministratorViewModel : EntityViewModelPersistent<Guid, Administrator>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public DateTime? CreationAt { get; set; }
        public string Password { get; set; }
        public uint ConcurrencyToken { get; set; }

        /// <summary>
        /// Convert to entity
        /// </summary>
        /// <param name="viewModel"></param>

        public static explicit operator Administrator(AdministratorViewModel viewModel) => viewModel.Map<Administrator>();
    }
}

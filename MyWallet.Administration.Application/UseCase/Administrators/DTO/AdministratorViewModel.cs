using System;

namespace MyWallet.Administration.Application.UseCase.Administrators.DTO
{
    using MyWallet.Administration.Application.UseCase;
    public class AdministratorViewModel : EntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public DateTime? CreationAt { get; set; }
        public string Password { get; set; }
    }
}

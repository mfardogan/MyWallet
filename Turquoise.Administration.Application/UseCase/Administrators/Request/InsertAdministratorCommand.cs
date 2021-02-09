using MediatR;

namespace MyWallet.Administration.Application.UseCase.Administrators.Request
{
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    public class InsertAdministratorCommand : IRequest
    {
        public AdministratorViewModel AdministratorViewModel { get; set; }
    }
}

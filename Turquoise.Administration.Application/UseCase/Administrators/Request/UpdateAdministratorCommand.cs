using MediatR;

namespace MyWallet.Administration.Application.UseCase.Administrators.Request
{
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    public class UpdateAdministratorCommand : IRequest
    {
        public AdministratorViewModel ViewModel { get; set; }
    }
}

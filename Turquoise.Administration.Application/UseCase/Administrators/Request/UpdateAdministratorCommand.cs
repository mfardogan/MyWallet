using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.Request
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class UpdateAdministratorCommand : IRequest
    {
        public AdministratorViewModel ViewModel { get; set; }
    }
}

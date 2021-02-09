using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.Request
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class InsertAdministratorCommand : IRequest
    {
        public AdministratorViewModel AdministratorViewModel { get; set; }
    }
}

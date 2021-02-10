using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class InsertAdministrator : IRequest
    {
        public AdministratorViewModel AdministratorViewModel { get; set; }
    }
}

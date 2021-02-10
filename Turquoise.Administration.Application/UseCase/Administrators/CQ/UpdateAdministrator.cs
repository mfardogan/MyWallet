using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class UpdateAdministrator : IRequest
    {
        public AdministratorViewModel ViewModel { get; set; }
    }
}

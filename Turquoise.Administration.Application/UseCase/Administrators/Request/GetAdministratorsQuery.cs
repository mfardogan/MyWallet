using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.Request
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class GetAdministratorsQuery : IRequest<AdministratorViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public AdministratorViewModel Filters { get; set; }
    }
}

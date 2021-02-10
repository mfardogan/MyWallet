using MediatR;

namespace Turquoise.Administration.Application.UseCase.Administrators.CQ
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;

    public class SearchAdministrators : IRequest<AdministratorViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public AdministratorViewModel Filters { get; set; }
    }
}

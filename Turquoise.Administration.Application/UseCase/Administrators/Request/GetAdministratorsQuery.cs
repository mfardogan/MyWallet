using MediatR;

namespace MyWallet.Administration.Application.UseCase.Administrators.Request
{
    using MyWallet.Administration.Domain.Aggregation.Common;
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    public class GetAdministratorsQuery : IRequest<AdministratorViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public AdministratorViewModel Filters { get; set; }
    }
}

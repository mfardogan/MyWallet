using MediatR;

namespace MyWallet.Administration.Application.UseCase.Administrators.CQ
{
    using MyWallet.Administration.Domain.Aggregation.Common;
    using MyWallet.Administration.Domain.Aggregation.Administrator;

    public class GetAdministratorsQuery : IRequest<Administrator[]>
    {
        public Pagination Pagination { get; set; }
        public Administrator FilterClauses { get; set; }
    }
}

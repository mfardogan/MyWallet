using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.CQ;
    using MyWallet.Administration.Application.UseCase.Administrators.DTO;

    public class AdministratorQueryHandler : IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceHandler<IAdministratorDAO> serviceHandler =
            new ServiceHandler<IAdministratorDAO>();

        public AdministratorQueryHandler()
        {
            dAO = serviceHandler.DataAccessObject;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            Administrator administrator = dAO.Get(request.Id);
            return serviceHandler.Success(administrator.Map<AdministratorViewModel>());
        }
    }
}

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.CQ;

    public class AdministratorCommandHandler : IRequestHandler<GetAdministratorsQuery, Administrator[]>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceHandler<IAdministratorDAO> serviceHandler =
            new ServiceHandler<IAdministratorDAO>();

        public AdministratorCommandHandler()
        {
            dAO = serviceHandler.DataAccessObject;
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Administrator[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            Administrator[] administrators = dAO.Get(_ => true);
            return serviceHandler.Success(administrators);
        }
    }
}

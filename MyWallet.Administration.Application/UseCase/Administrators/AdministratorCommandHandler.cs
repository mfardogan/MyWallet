using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.CQ;

    public class AdministratorCommandHandler : IRequestHandler<GetAdministratorsQuery, Administrator[]>
    {
        private readonly ServiceHandler<IAdministratorService> serviceHandler =
            new ServiceHandler<IAdministratorService>();

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Administrator[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            using (ITransaction scope = serviceHandler.UoW.BeginTransaction())
            {
                serviceHandler.AggregationService.Insert(new Administrator()
                {
                    Name = "Faruk",
                    Surname = "Kanbur",
                    FullName = "Faruk Kanbur",
                });

                await scope.CommitAsync();
                await serviceHandler.UoW.SaveAsync();
            }

            Administrator[] administrators = serviceHandler.AggregationService.Get(_ => true);
            return administrators;
        }
    }
}

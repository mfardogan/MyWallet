using MediatR;
using MyWallet.Administration.Application.UseCase.Administrators.CQ;
using MyWallet.Administration.Domain.Abstraction;
using MyWallet.Administration.Domain.Aggregation.Administrator;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    public class AdministratorCommandHandler : IRequestHandler<GetAdministratorsQuery, Administrator[]>
    {
        private readonly ServiceHandler<IAdministratorService> serviceHandler =
            new ServiceHandler<IAdministratorService>();

        public async Task<Administrator[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            using (ITransaction scope = serviceHandler.UoW.BeginTransaction())
            {
                serviceHandler.Service.Insert(new Administrator()
                {
                    Name = "Faruk",
                    Surname = "Kanbur",
                    FullName = "Faruk Kanbur",
                });

                await scope.CommitAsync();
                await serviceHandler.UoW.SaveChangesAsync();
            }

            Administrator[] administrators = serviceHandler.Service.Get(x => true);
            return administrators;
        }
    }
}

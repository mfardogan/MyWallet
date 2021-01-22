using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.Request;

    public class AdministratorCommandHandler :
        IRequestHandler<InsertAdministratorCommand>,
        IRequestHandler<UpdateAdministratorCommand>,
        IRequestHandler<DeleteAdministratorCommand>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceStub<IAdministratorDAO> serviceStub =
            new ServiceStub<IAdministratorDAO>();

        public AdministratorCommandHandler()
        {
            dAO = serviceStub.DataAccessObject;
        }

        public async Task<Unit> Handle(InsertAdministratorCommand request, CancellationToken cancellationToken)
        {
            Administrator administrator = request.AdministratorViewModel.Map<Administrator>();
            dAO.Insert(administrator);

            await serviceStub.UoW.SaveAsync();
            return serviceStub.Success();
        }

        public async Task<Unit> Handle(DeleteAdministratorCommand request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.AdministratorId);
            await serviceStub.UoW.SaveAsync();
            return serviceStub.Success();
        }

        public async Task<Unit> Handle(UpdateAdministratorCommand request, CancellationToken cancellationToken)
        {
            Administrator administrator = request.AdministratorViewModel.Map<Administrator>();
            dAO.Update(administrator);

            await serviceStub.UoW.SaveAsync();
            return serviceStub.Success();
        }
    }
}

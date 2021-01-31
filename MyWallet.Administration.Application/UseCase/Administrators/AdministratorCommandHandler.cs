using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase.Administrators
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Application.UseCase.Administrators.Request;
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain;

    public class AdministratorCommandHandler :
        IRequestHandler<InsertAdministratorCommand>,
        IRequestHandler<UpdateAdministratorCommand>,
        IRequestHandler<DeleteAdministratorCommand>
    {
        private readonly IAdministratorDAO dAO;
        private readonly ServiceStub<IAdministratorDAO> serviceStub =
            new ServiceStub<IAdministratorDAO>();

        private readonly ISaltFactory saltFactory;
        private readonly IPasswordHasher passwordHasher;
        public AdministratorCommandHandler()
        {
            dAO = serviceStub.DataAccessObject;
            saltFactory = Dependency.Get<ISaltFactory>();
            passwordHasher = Dependency.Get<IPasswordHasher>();
        }

        public async Task<Unit> Handle(InsertAdministratorCommand request, CancellationToken cancellationToken)
        {
            var salt = saltFactory.Generate();
            var hash = passwordHasher.Compute(request.AdministratorViewModel.Password, salt);
            Administrator administrator = request.AdministratorViewModel;
            administrator.AddPassword(salt, hash);
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
            dAO.Update(request.ViewModel);
            await serviceStub.UoW.SaveAsync();
            return serviceStub.Success();
        }
    }
}

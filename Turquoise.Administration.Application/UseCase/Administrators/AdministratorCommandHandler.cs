using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.DomainEvent;
    using Turquoise.Administration.Domain.Aggregation.Choice;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.Request;
    public class AdministratorCommandHandler :
        IRequestHandler<InsertAdministratorCommand>,
        IRequestHandler<UpdateAdministratorCommand>,
        IRequestHandler<DeleteAdministratorCommand>
    {
        private readonly BussinesProxy<IAdministratorDAO> service;

        private readonly ISaltFactory saltFactory;
        private readonly IPasswordHasher passwordHasher;
        public AdministratorCommandHandler()
        {
            service = new BussinesProxy<IAdministratorDAO>();
            saltFactory = Dependency.Get<ISaltFactory>();
            passwordHasher = Dependency.Get<IPasswordHasher>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertAdministratorCommand request, CancellationToken cancellationToken)
        {
            var salt = saltFactory.Generate();
            var hash = passwordHasher.Compute(request.AdministratorViewModel.Password, salt);
            Administrator administrator = request.AdministratorViewModel;
            administrator.AddPassword(salt, hash);
            
            service.DataAccessObject.Insert(administrator);
            await service.SaveAsync();

            await service.HandleEvent(new GenericEvent<IEnumerable<Choice>>(null));
            return service.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteAdministratorCommand request, CancellationToken cancellationToken)
        {
            service.DataAccessObject.Delete(request.AdministratorId);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateAdministratorCommand request, CancellationToken cancellationToken)
        {
            service.DataAccessObject.Update(request.ViewModel);
            await service.SaveAsync();
            return service.Success();
        }
    }
}

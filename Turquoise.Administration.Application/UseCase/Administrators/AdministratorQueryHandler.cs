using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    using Turquoise.Administration.Application.UseCase.Administrators.Request;

    public partial class AdministratorHandler :
        IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel>,
        IRequestHandler<GetAdministratorsQuery, AdministratorViewModel[]>
    {    
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            Administrator administrator = dAO.Get(request.Id);
            return service.Success(administrator.Map<AdministratorViewModel>());
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel[]> Handle(GetAdministratorsQuery request, CancellationToken cancellationToken)
        {
            Specification<Administrator, AdministratorViewModel> specify =
                new AdministratorSpecify(request.Filters);

            AdministratorViewModel[] administrators =
               dAO.Get(specify.GetFilters(), request.Pagination)
               .Map<AdministratorViewModel>()
               .ToArray();

            return service.Success(administrators);
        }
    }
}

using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Administrators
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Application.UseCase.Administrators.DTO;
    using Turquoise.Administration.Application.UseCase.Administrators.CQ;

    public partial class AdministratorCQHandler :
        IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel>,
        IRequestHandler<SearchAdministratorsQuery, AdministratorViewModel[]>
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
            return bussines.Success(administrator.Map<AdministratorViewModel>());
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdministratorViewModel[]> Handle(SearchAdministratorsQuery request, CancellationToken cancellationToken)
        {
            Specification<Administrator, AdministratorViewModel> specify =
                new AdministratorSpecify(request.Filters);

            AdministratorViewModel[] administrators =
               dAO.Get(specify.GetExpressions(), request.Pagination)
               .Map<AdministratorViewModel>()
               .ToArray();

            return bussines.Success(administrators);
        }
    }
}

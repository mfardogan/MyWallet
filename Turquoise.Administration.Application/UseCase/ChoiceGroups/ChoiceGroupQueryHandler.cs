using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups
{
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public partial class ChoiceGroupCQHandler :
        IRequestHandler<GetChoiceGroupById, ChoiceGroupViewModel>,
        IRequestHandler<SearchChoiceGroups, ChoiceGroupViewModel[]>
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ChoiceGroupViewModel> Handle(GetChoiceGroupById request, CancellationToken cancellationToken)
        {
            ChoiceGroup choiceGroup = dAO.Get(request.ChoiceGroupId);
            ChoiceGroupViewModel choiceGroupViewModel = choiceGroup.Map<ChoiceGroupViewModel>();
            return service.Success(choiceGroupViewModel);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ChoiceGroupViewModel[]> Handle(SearchChoiceGroups request, CancellationToken cancellationToken)
        {
            ChoiceGroupSpecify specify = new ChoiceGroupSpecify(request.Filters);
            ChoiceGroupViewModel[] choiceGroups =
                dAO.Get(specify.GetExpressions(), request.Pagination)
                .Map<ChoiceGroupViewModel>()
                .ToArray();

            return service.Success(choiceGroups);
        }
    }
}

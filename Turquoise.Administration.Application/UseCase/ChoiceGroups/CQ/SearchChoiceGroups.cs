using MediatR;

namespace Turquoise.Administration.Application.UseCase.ChoiceGroups.CQ
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Application.UseCase.ChoiceGroups.DTO;

    public class SearchChoiceGroups : IRequest<ChoiceGroupViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public ChoiceGroupViewModel Filters { get; set; }
    }
}

using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Surveys
{
    using Turquoise.Administration.Application.UseCase.Surveys.CQ;
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;

    public partial class SurveyCQHandler :
        IRequestHandler<GetSurveyById, SurveyViewModel>,
        IRequestHandler<SearchSurveys, SurveyViewModel[]>
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SurveyViewModel> Handle(GetSurveyById request, CancellationToken cancellationToken)
        {
            SurveyViewModel surveyViewModel = dAO.Get(request.SurveyId).Map<SurveyViewModel>();
            return service.Success(surveyViewModel);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SurveyViewModel[]> Handle(SearchSurveys request, CancellationToken cancellationToken)
        {
            var pagination = request.Pagination;
            var specify = new SurveySpecify(request.Filters);

            SurveyViewModel[] surveyViewModels =
                dAO.Get(specify.GetFilters(), pagination)
                .Map<SurveyViewModel>()
                .ToArray();
            return service.Success(surveyViewModels);
        }
    }
}

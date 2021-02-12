using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers
{
    using System.Linq;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO;
    using Turquoise.Administration.Domain.Aggregation.SurveyAnswer;

    public partial class SurveyAnswerCQHandler :
        IRequestHandler<GetSurveyAnswerById, SurveyAnswerViewModel>,
        IRequestHandler<SearchSurveyAnswers, SurveyAnswerViewModel[]>
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SurveyAnswerViewModel> Handle(GetSurveyAnswerById request, CancellationToken cancellationToken)
        {
            SurveyAnswer surveyAnswer = dAO.Get(request.SurveyAnswerId);
            SurveyAnswerViewModel surveyAnswerViewModel = surveyAnswer.Map<SurveyAnswerViewModel>();
            return service.Success(surveyAnswerViewModel);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SurveyAnswerViewModel[]> Handle(SearchSurveyAnswers request, CancellationToken cancellationToken)
        {
            var pagination = request.Pagination;
            var specify = new SurveyAnswerSpecify(request.Filters);

            SurveyAnswerViewModel[] surveyAnswerViewModels =
                dAO.Get(specify.GetExpressions(), pagination)
                .Map<SurveyAnswerViewModel>()
                .ToArray();
            return service.Success(surveyAnswerViewModels);
        }
    }
}

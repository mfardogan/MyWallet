using MediatR;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class UpdateSurveyCommand : IRequest
    {
        public SurveyViewModel SurveyViewModel { get; set; }
    }
}
